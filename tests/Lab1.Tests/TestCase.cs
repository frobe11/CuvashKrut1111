using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Service;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TestCase
{
    [Theory]
    [ClassData(typeof(PleasureShuttleAndAvgur_NebulaeOfIncreasedDensity_Data))]
    public void PleasureShuttleAndAvgur_NebulaeOfIncreasedDensity_SpacecraftLost(ISpacecraft spacecraft, Route route)
    {
        Assert.True(route.GoThroughTheRote(spacecraft) is GoThroughTheRoteResult.SpacecraftLost);
    }

    [Theory]
    [ClassData(typeof(VaklasAndVaklasWithPhotoneDeflector_NebulaeOfIncreasedDensityWithAntimatterFlare_Data))]
    public void VaklasAndVaklasWithPhotoneDeflector_NebulaeOfIncreasedDensityWithAntimatterFlare_CrewDiedAndSuccess(
        ISpacecraft spacecraft, Route route)
    {
        var obstacle = new AntimatterFlare();
        var obstacles = new List<INebulaeOfIncreasedDensityObstacle> { obstacle };
        var partOfTheWay = new NebulaeOfIncreasedDensity(
            500,
            obstacles);
        route.AddPartOfTheWay(partOfTheWay);
        if (spacecraft is ISpacecraftWithDeflector { Deflector: IDeflectorWithPhotonDeflector } spacecraftWithDeflector) Assert.True(route.GoThroughTheRote(spacecraft) is GoThroughTheRoteResult.Success);
        else Assert.True(route.GoThroughTheRote(spacecraft) is GoThroughTheRoteResult.CrewDied);
    }

    [Theory]
    [ClassData(typeof(VaklasAndAvgurAndMeredian_NebulaeOfNitrineParticlesWithSpacewhale_Data))]
    public void VaklasAndAvgurAndMeredian_NebulaeOfNitrineParticlesWithSpacewhale_SpacecraftDestroyedAndSuccess(ISpacecraft spacecraft, Route route)
    {
        var obstacle = new SpaceWhale();
        var obstacles = new List<INebulaeOfNitrineParticlesObstacle> { obstacle };
        var partOfTheWay = new NebulaeOfNitrineParticles(
            500,
            obstacles);
        route.AddPartOfTheWay(partOfTheWay);
        switch (spacecraft)
        {
            case Vaklas:
                Assert.True(route.GoThroughTheRote(spacecraft) is GoThroughTheRoteResult.SpacecraftDestroyed);
                break;
            case Avgyr:
                Assert.True(route.GoThroughTheRote(spacecraft) is GoThroughTheRoteResult.Success);
                break;
            case Meredian:
                Assert.True(route.GoThroughTheRote(spacecraft) is GoThroughTheRoteResult.Success);
                break;
        }
    }

    [Fact]
    public void PleasureShuttleAndVaklas_Space_PleasureShuttleIsBest()
    {
        var space = new Space(100, new List<ISpaceObstacle>());
        var route = new Route(new List<IEnvironment> { space });
        var spacecrafts = new List<GoThroughTheRoteResult>
        {
            route.GoThroughTheRote(new Vaklas()),
            route.GoThroughTheRote(new PleasureShuttle()),
        };
        var chooseBestSpacecraft = new ChooseBestSpacecraft();
        Assert.True(chooseBestSpacecraft.Choose(spacecrafts) is PleasureShuttle);
    }

    [Fact]
    public void AvgurAndStella_NebulaeOfNitrineParticles_StellaIsBest()
    {
        var nebulae = new NebulaeOfIncreasedDensity(1023, new List<INebulaeOfIncreasedDensityObstacle>());
        var route = new Route(new List<IEnvironment> { nebulae });
        var spacecrafts = new List<GoThroughTheRoteResult>
        {
            route.GoThroughTheRote(new Avgyr()),
            route.GoThroughTheRote(new Stella()),
        };
        var chooseBestSpacecraft = new ChooseBestSpacecraft();
        Assert.True(chooseBestSpacecraft.Choose(spacecrafts) is Stella);
    }

    [Fact]
    public void PleasureShuttleAndVaklas_NebulaeOfNitrineParticles_VaklasIsBest()
    {
        var nebulae = new NebulaeOfNitrineParticles(1000, new List<INebulaeOfNitrineParticlesObstacle>());
        var route = new Route(new List<IEnvironment> { nebulae });
        var spacecrafts = new List<GoThroughTheRoteResult>
        {
            route.GoThroughTheRote(new Vaklas()),
            route.GoThroughTheRote(new PleasureShuttle()),
        };
        var chooseBestSpacecraft = new ChooseBestSpacecraft();
        Assert.True(chooseBestSpacecraft.Choose(spacecrafts) is Vaklas);
    }

    [Fact]
    public void PleasureShuttleAndMeredianAndStella_SpaceWithMeteorsAndAsteroidsAndNebulaeWithWhale_MeredianIsBest()
    {
        var spaceObstacles = new List<ISpaceObstacle>
        {
            new Meteor(),
            new Asteroid(),
        };
        var space = new Space(1000, spaceObstacles);
        var nebulaeObstacles = new List<INebulaeOfNitrineParticlesObstacle>();
        var nebulae = new NebulaeOfNitrineParticles(1000, nebulaeObstacles);
        var route = new Route(new List<IEnvironment>
        {
            space,
            nebulae,
        });
        var spacecrafts = new List<GoThroughTheRoteResult>
        {
            route.GoThroughTheRote(new PleasureShuttle()),
            route.GoThroughTheRote(new Stella()),
            route.GoThroughTheRote(new Meredian()),
        };
        var chooseBestSpacecraft = new ChooseBestSpacecraft();
        Assert.True(chooseBestSpacecraft.Choose(spacecrafts) is Meredian);
    }

    public class PleasureShuttleAndAvgur_NebulaeOfIncreasedDensity_Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new PleasureShuttle(),
                new Route(new List<IEnvironment>()),
            },
            new object[]
            {
                new Avgyr(),
                new Route(new List<IEnvironment>()),
            },
        };

        public PleasureShuttleAndAvgur_NebulaeOfIncreasedDensity_Data()
        {
            if (_data[0][1] is Route route1)
            {
                route1.AddPartOfTheWay(new NebulaeOfIncreasedDensity(
                    2000,
                    new List<INebulaeOfIncreasedDensityObstacle>()));
            }

            if (_data[1][1] is Route route2)
            {
                route2.AddPartOfTheWay(new NebulaeOfIncreasedDensity(
                    2000,
                    new List<INebulaeOfIncreasedDensityObstacle>()));
            }
        }

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class VaklasAndVaklasWithPhotoneDeflector_NebulaeOfIncreasedDensityWithAntimatterFlare_Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new Vaklas(),
                new Route(new List<IEnvironment>()),
            },
            new object[]
            {
                new Vaklas(true),
                new Route(new List<IEnvironment>()),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class VaklasAndAvgurAndMeredian_NebulaeOfNitrineParticlesWithSpacewhale_Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new Vaklas(),
                new Route(new List<IEnvironment>()),
            },
            new object[]
            {
                new Avgyr(),
                new Route(new List<IEnvironment>()),
            },
            new object[]
            {
                new Meredian(),
                new Route(new List<IEnvironment>()),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}