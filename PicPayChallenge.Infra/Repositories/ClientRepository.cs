using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.Repositories;
using PicPayChallenge.Infra.Entities;

namespace PicPayChallenge.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private UserEntityRepository userEntityRepository;
        public ClientRepository(PicPayContext picPayContext)
        {
            userEntityRepository = new UserEntityRepository(picPayContext);
        }

        public Client Create(Client client)
        {
            return userEntityRepository.Create(ClientEntity.FromDomain(client)).ToClient();
        }
        public bool ExistsByEmailOrCpf(string email, string cpf)
        {
            return userEntityRepository.ExistsByEmailOrDocument(email, cpf);
        }
        public Client? FindByEmail(string email)
        {
            var entity = userEntityRepository.FindByEmail(email);
            if (entity == null) {
                return null;
            }
            return entity.ToClient();
        }
        public Client? FindById(int Id)
        {
            var entity = userEntityRepository.FindById(Id);
            if (entity == null) return null;
            if(entity.Kind != UserKind.CLIENT) return null;
            return entity.ToClient();
        }
    }
}
