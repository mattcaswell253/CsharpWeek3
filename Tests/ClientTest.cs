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

      public void Dispose()
      {
        Client.DeleteAll();
      }
    }
}
