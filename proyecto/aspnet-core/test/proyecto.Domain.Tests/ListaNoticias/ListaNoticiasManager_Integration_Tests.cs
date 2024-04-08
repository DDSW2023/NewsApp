using proyecto.ListaNoticias;
using Volo.Abp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Identity;
using Shouldly;
using Volo.Abp.Users;
using Volo.Abp.Security.Claims;
using Volo.Abp.Domain.Repositories;

namespace proyecto.ListaNoticia
{
    public class ListaNoticiaManager_Integration_Tests : proyectoDomainTestBase
    {
        private readonly ListaNoticiaManager _listaNoticiaManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICurrentUser _currentUser;
        private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;
        private readonly IRepository<IdentityUser, Guid> _identityRepository;

        public ListaNoticiaManager_Integration_Tests()
        {
            _listaNoticiaManager = GetRequiredService<ListaNoticiaManager>();
            _userManager = GetRequiredService<UserManager<IdentityUser>>();
            _currentUser = GetRequiredService<ICurrentUser>();
            _currentPrincipalAccessor = GetRequiredService<ICurrentPrincipalAccessor>();
            _identityRepository = GetRequiredService<IRepository<IdentityUser, Guid>>();
        }

        [Fact]
        public async Task Should_Assign_An_Issue_To_A_User()
        {
            // Arrange
            int? id = null;
            var name = "ListaNoticia agregado";
            int? parentId = null;
            var user = await _userManager.FindByIdAsync(_currentUser.Id.GetValueOrDefault().ToString());
            var user2 = await _identityRepository.GetAsync(_currentUser.Id.GetValueOrDefault());

            // Act
            var listaNoticia = await _listaNoticiaManager.CreateAsyncOrUpdate(id, name, parentId, user2);

            //Assert
            listaNoticia.ShouldNotBeNull();

        }
        
    }
}