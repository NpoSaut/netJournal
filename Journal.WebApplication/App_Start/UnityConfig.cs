using System;
using Journal.Data.Sql.Repositories;
using Journal.Model;
using Journal.WebApplication.Models.Burndown;
using Journal.WebApplication.ViewModels;
using Journal.WebApplication.ViewModels.NameFormatters;
using Microsoft.Practices.Unity;

namespace Journal.WebApplication.App_Start
{
    /// <summary>Specifies the Unity configuration for the main container.</summary>
    public class UnityConfig
    {
        #region Unity Container

        private static readonly Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
                                                                                            {
                                                                                                var container = new UnityContainer();
                                                                                                RegisterTypes(container);
                                                                                                return container;
                                                                                            });

        /// <summary>Gets the configured Unity container.</summary>
        public static IUnityContainer GetConfiguredContainer() { return container.Value; }

        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        ///     There is no need to register concrete types such as controllers or API controllers (unless you want to change
        ///     the defaults), as Unity allows resolving a concrete type even if it was not previously registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUsersRepository, UsersRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ISessionsRepository, SessionsRepository>(new PerRequestLifetimeManager());

            container.RegisterType<IUserModelProvider, RepositoryUserModelProvider>(new PerRequestLifetimeManager());
            container.RegisterType<ISessionModelProvider, RepositorySessionModelProvider>(new PerRequestLifetimeManager());
            container.RegisterType<IUserManager, UserManager>(new PerRequestLifetimeManager());
            container.RegisterType<IUserActivator, UserActivator>(new PerRequestLifetimeManager());
            container.RegisterType<IUserDetailsProvider, ActiveDirectoryUserDetailsProvider>(new ContainerControlledLifetimeManager());

            container.RegisterType<IHomeViewModelProvider, HomeViewModelProvider>(new PerRequestLifetimeManager());
            container.RegisterType<IUserViewModelProvider, UserViewModelProvider>(new PerRequestLifetimeManager());
            container.RegisterType<ISessionViewModelProvider, SessionViewModelProvider>(new PerRequestLifetimeManager());
            container.RegisterType<IAppealFormatter, NameAndPatronymicAppealFormatter>(new ContainerControlledLifetimeManager());
            container.RegisterType<IFullNameFormatter, FullNameFormatter>(new ContainerControlledLifetimeManager());

            container.RegisterType<IWorktimeCalculator, SimpleWorktimeCalculator>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBurndownModelProvider, BurndownModelProvider>(new ContainerControlledLifetimeManager());
        }
    }
}
