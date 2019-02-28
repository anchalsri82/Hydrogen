using NUnit.Framework;
using Hydrogen.Modules.AboutModule;
using Prism.Regions;
using Autofac;
using Hydrogen.Infra.Service;
using Moq;
using Hydrogen.Infra.Service.Events;
using Autofac.Core;
using System;

namespace Hydrogen.Tests.Modules.AboutModule
{
    [TestFixture]
    public class AboutModule
    {
        [Test]
        public void TestModuleInitInitialize()
        {
            //Arrange
            Mock<IRegionManager> mockRegionManager = new Mock<IRegionManager>();
            Mock<IMenuService> mockMenuService = new Mock<IMenuService>();
            Mock<IContainer> mockContainer = new Mock<IContainer>();
            Mock<IComponentRegistry> mockContainerRegistry = new Mock<IComponentRegistry>();
            mockContainer.Setup(p => p.ComponentRegistry).Returns(mockContainerRegistry.Object);
            ModuleInit moduleInit = new ModuleInit(mockRegionManager.Object, mockContainer.Object, mockMenuService.Object);

            //Act
            moduleInit.Initialize();

            //Assert
            mockMenuService.Verify(x => x.Register(It.Is<MenuItemArgs>(p => p.NavigationPath == ModuleInit.AboutView && p.Path == ModuleInit.AboutMenuPath)), Times.Once());
        }

        [Test]
        public void TestModuleInitInitializeException()
        {
            //Arrange
            Mock<IRegionManager> mockRegionManager = new Mock<IRegionManager>();
            Mock<IMenuService> mockMenuService = new Mock<IMenuService>();
            Mock<IContainer> mockContainer = new Mock<IContainer>();
            Mock<IComponentRegistry> mockContainerRegistry = new Mock<IComponentRegistry>();
            mockMenuService.Setup(x => x.Register(It.IsAny<MenuItemArgs>())).Throws<InvalidOperationException>();
            ModuleInit moduleInit = new ModuleInit(mockRegionManager.Object, mockContainer.Object, mockMenuService.Object);

            //Act
            
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                moduleInit.Initialize();
            });
            mockMenuService.Verify(x => x.Register(It.Is<MenuItemArgs>(p => p.NavigationPath == ModuleInit.AboutView && p.Path == ModuleInit.AboutMenuPath)), Times.Once());
        }
    }
}
