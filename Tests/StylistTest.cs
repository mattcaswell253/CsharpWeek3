using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class StylistTest : IDisposable
    {
      public StylistTest()
      {
        DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
      }

      [Fact]
      public void StylistTest_DatabaseEmptyAtFirst_True()
      {
        //Arrange, Act
        int result = Stylist.GetAll().Count;

        //Assert
        Assert.Equal(0, result);
      }

      [Fact]
      public void StylistTest_ReturnsTrueIfDescriptionsAreTheSame_True()
      {
        //Arrange, Act
        Stylist firstStylist = new Stylist("Jackie", 1);
        Stylist secondStylist = new Stylist("Jackie", 1);

        //Assert
        Assert.Equal(firstStylist, secondStylist);
      }

      [Fact]
      public void StylistTest_Save_SavesToDataBase()
      {
        //Arrange
        Stylist testStylist = new Stylist("Jackie");

        //Act
        testStylist.Save();
        List<Stylist> result = Stylist.GetAll();
        List<Stylist> testList = new List<Stylist>{testStylist};

        //Assert
        Assert.Equal(testList, result);
      }





      public void Dispose()
      {
        Stylist.DeleteAll();
      }
    }
}
