using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class ClientTest : IDisposable
    {
      public ClientTest()
      {
        DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
      }

      [Fact]
      public void ClientTest_DatabaseEmptyAtFirst_True()
      {
        //Arrange, Act
        int result = Client.GetAll().Count;

        //Assert
        Assert.Equal(0, result);
      }

      [Fact]
      public void ClientTest_ReturnsTrueIfDescriptionsAreTheSame_True()
      {
        //Arrange, Act
        Client firstClient = new Client("Jackie", 1);
        Client secondClient = new Client("Jackie", 1);

        //Assert
        Assert.Equal(firstClient, secondClient);
      }

      [Fact]
      public void ClientTest_Save_SavesToDataBase()
      {
        //Arrange
        Client testClient = new Client("Jackie", 1);

        //Act
        testClient.Save();
        List<Client> result = Client.GetAll();
        List<Client> testList = new List<Client>{testClient};

        //Assert
        Assert.Equal(testList, result);
      }

      [Fact]
      public void ClientTest_Assigns_AssignsIdToObject()
      {
        //Arrange
        Client testClient = new Client("Jackie", 1);

        //Act
        testClient.Save();
        Client savedClient = Client.GetAll()[0];

        int result = savedClient.GetId();
        int testId = testClient.GetId();

        //Assert
        Assert.Equal(testId, result);
      }

      [Fact]
      public void ClientTest_Find_FindsClientInDataBase()
      {
        //Arrange
        Client testClient = new Client("Jackie", 1);
        testClient.Save();

        //Act
        Client foundClient = Client.Find(testClient.GetId());

        //Assert
        Assert.Equal(testClient, foundClient);
      }


      public void Dispose()
      {
        Client.DeleteAll();
      }
    }
}
