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


      public void Dispose()
      {
        Client.DeleteAll();
      }
    }
}
