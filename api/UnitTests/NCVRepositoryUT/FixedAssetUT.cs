using NinosConValorAPI.Data.Entity;
using NinosConValorAPI.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.DBUT;

namespace UnitTests.NCVRepositoryUT
{
    
    public class FixedAssetUT:BaseTest
    {
        [Fact]
        public async Task CreateFixedAsset_AddFixedAssetToEmptyDB_ReturnsTrueSavedCorrectly()
        {
            // ARRANGE
            var repository = new NCVRepository(ctx);
            var fixedAsset = new FixedAssetEntity()
            {
                Id = 1,
                Name = "Computadora",
                Description = "Computadora de escritorio",
                EntryDate = new DateTime(2001, 3, 2),
                Price = 100.58m,
                Features = "8Gb de RAM",
                Quantity = 5
            };

            // ACT 
            repository.CreateFixedAsset(fixedAsset);
            var result = await repository.SaveChangesAsync();

            // ASSERT
            Assert.True(result);
        }

        [Fact]
        public async Task GetFixedAssets_ReturnListOfFixedAssets()
        {
            // CREATE 1 FIXED ASSET
            var repository = new NCVRepository(ctx);
            var fixedAsset = new FixedAssetEntity()
            {
                Id = 1,
                Name = "Computadora",
                Description = "Computadora de escritorio",
                EntryDate = new DateTime(2001, 3, 2),
                Price = 100.58m,
                Features = "8Gb de RAM",
                Quantity = 5
            };
            repository.CreateFixedAsset(fixedAsset);
            var result = await repository.SaveChangesAsync();

            // NUMBER OF FIXED ASSETS
            var listFixedAssets = await repository.GetFixedAssetsAsync();
            var numberOfFixedAssets = listFixedAssets.Count();
            Assert.Equal(1,numberOfFixedAssets);
        }

        [Fact]
        public async Task GetFixedAssets_ReturnFixedAssetName()
        {
            // CREATE 1 FIXED ASSET
            var repository = new NCVRepository(ctx);
            var fixedAsset = new FixedAssetEntity()
            {
                Id = 1,
                Name = "Computadora",
                Description = "Computadora de escritorio",
                EntryDate = new DateTime(2001, 3, 2),
                Price = 100.58m,
                Features = "8Gb de RAM",
                Quantity = 5
            };
            repository.CreateFixedAsset(fixedAsset);
            var result = await repository.SaveChangesAsync();

            // NUMBER OF FIXED ASSETS
            var listFixedAssets = await repository.GetFixedAssetsAsync();
            //var numberOfFixedAssets = listFixedAssets.Count();
            Assert.Equal("Computadora", listFixedAssets.First().Name);
        }

        [Fact]
        public async Task GetFixedAsset_ReturnFixedAssetName()
        {
            // CREATE 1 FIXED ASSET
            var repository = new NCVRepository(ctx);
            var fixedAsset = new FixedAssetEntity()
            {
                Id = 1,
                Name = "Computadora",
                Description = "Computadora de escritorio",
                EntryDate = new DateTime(2001, 3, 2),
                Price = 100.58m,
                Features = "8Gb de RAM",
                Quantity = 5
            };
            repository.CreateFixedAsset(fixedAsset);
            var result = await repository.SaveChangesAsync();

            // RETURN THE FIRST FIXED ASSET
            var firstFixedAsset = await repository.GetFixedAssetAsync(1);
            //var numberOfFixedAssets = listFixedAssets.Count();
            Assert.Equal("Computadora", firstFixedAsset.Name);
        }

        [Fact]
        public async Task GetFixedAsset_ReturnFixedAssetPrice()
        {
            // CREATE 1 FIXED ASSET
            var repository = new NCVRepository(ctx);
            var fixedAsset = new FixedAssetEntity()
            {
                Id = 1,
                Name = "Computadora",
                Description = "Computadora de escritorio",
                EntryDate = new DateTime(2001, 3, 2),
                Price = 100.58m,
                Features = "8Gb de RAM",
                Quantity = 5
            };
            repository.CreateFixedAsset(fixedAsset);
            var result = await repository.SaveChangesAsync();

            // RETURN THE FIRST FIXED ASSET
            var firstFixedAsset = await repository.GetFixedAssetAsync(1);
            //var numberOfFixedAssets = listFixedAssets.Count();
            Assert.Equal(100.58m, firstFixedAsset.Price);
        }
    }
}
