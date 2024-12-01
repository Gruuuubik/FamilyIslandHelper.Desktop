﻿using FamilyIslandHelper.Api.Helpers;
using Xunit;

namespace FamilyIslandHelper.Api.Net6.UnitTests
{
	public class BuildingHelperTests : BaseTest
	{
		[Theory]
		[InlineData(13)]
		public void When_GetBuildingsClasses_Then_ReturnCorrectCollection(int expectedCount)
		{
			var actualBuildingsClasses = BuildingHelper.GetBuildingsClasses();

			Assert.Equal(expectedCount, actualBuildingsClasses.Count);
			Assert.All(actualBuildingsClasses, (bc) => Assert.NotNull(bc));
		}

		[Fact]
		public void When_GetAllBuildingsNames_Then_AllBuildingsHaveFolders()
		{
			var actualBuildingsNames = BuildingHelper.GetBuildingsNames();

			var buildingsDirectories = Directory.GetDirectories(ItemHelper.FolderWithItemsPictures);
			var expectedBuildingsNames = buildingsDirectories.Select(b => b.Split(pathSeparator).Last());

			Assert.Equal(expectedBuildingsNames, actualBuildingsNames);
		}

		[Theory]
		[InlineData("Mill", new[] { "GoatFood", "ChickenFood", "Ocher", "Flour", "SunflowerOil", "Syrup", "CowFood" })]
		public void When_TryToGetItemsOfBuilding_Then_ReturnCorrectItems(string buildingName, IEnumerable<string> expectedItems)
		{
			var actualItems = BuildingHelper.GetItemsOfBuilding(buildingName);

			Assert.Equal(expectedItems, actualItems);
		}

		[Theory]
		[InlineData("buildingName")]
		public void When_CreateBuildingWithNullParameter_Then_ThrowsException(string expectedParamName)
		{
			var exception = Assert.Throws<ArgumentNullException>(() => BuildingHelper.CreateBuilding(null));

			Assert.Equal(expectedParamName, exception.ParamName);
		}

		[Theory]
		[InlineData("Knocker", new[] { "Pictures", "Buildings", "Knocker.png" })]
		public void When_GetBuildingImagePathByName_Then_ReturnCorrectValue(string buildingName, string[] expectedPath)
		{
			var actualPath = BuildingHelper.GetBuildingImagePathByName(buildingName);

			Assert.Equal(Path.Combine(expectedPath), actualPath);
		}
	}
}
