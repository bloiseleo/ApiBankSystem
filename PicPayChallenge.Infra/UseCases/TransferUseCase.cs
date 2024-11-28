using PicPayChallenge.Application.Services;
using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.Exceptions;
using PicPayChallenge.Domain.Repositories;
using PicPayChallenge.Domain.UseCases;

namespace PicPayChallenge.Infra.UseCases
{
    public class TransferUseCase(
        IWalletRepository walletRepository,
        IAuthorizeService authorizeService,
        ITransactionRepository transactionRepository,
        IEmailNotifierService emailNotifierService,
        PicPayContext context
    ): ITransferUseCase
    {
        private void registerTransaction(Decimal amount, User payer, User payee, TransactionStatus status)
        {
            transactionRepository.Create(new Transaction
            {
                Amount = amount,
                Status = status,
                From = payer,
                To = payee,
            });
            return;
        }
        public async Task<bool> Transfer(ITransferDTO transferDTO)
        {
            var payer = walletRepository.FindByUserId(transferDTO.Payer);
            var payee = walletRepository.FindByUserId(transferDTO.Payee);
            if (payer == null || payee == null)
            {
                throw new PayerOrPayeeNotFound(transferDTO.Payer, transferDTO.Payee);
            }
            if(payer.User is BusinessOwner)
            {
                throw new InvalidPayer();
            }
            if (payer.Amount < transferDTO.Value) 
            {
                throw new NotEnoughCredits();
            }
            using var transaction = context.Database.BeginTransaction();
            try
            {
                if (!await authorizeService.Authorize())
                {
                    registerTransaction(transferDTO.Value, payer.User, payee.User, TransactionStatus.Error);
                    transaction.Commit();
                    return false;
                };
                payer.Amount -= transferDTO.Value;
                payee.Amount += transferDTO.Value;
                walletRepository.UpdateWallets(new List<Wallet>() { payer, payee });
                registerTransaction(transferDTO.Value, payer.User, payee.User, TransactionStatus.Success);
                transaction.Commit();
            }
            catch (Exception) 
            {
                transaction.Rollback();
                throw;
            }
            await emailNotifierService.NotifyEmail(new Application.DTOs.EmailData
            {
                Body = $"You've just receieved R$ {transferDTO.Value}",
                Email = payee.User.Email,
                Subject = "Ops! You just received a transference"
            });
            return true;
        }
    }
}
