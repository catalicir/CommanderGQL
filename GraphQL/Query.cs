using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.GraphQL{

    public class Query{

        [UseDbContext(typeof(AppDbContext))] //tells the method to get a context from the pool when called and return the connection to the pool when finished
        //[UseProjection] //navigate the graph to pull all child objects in the tree
        // use ScopedService instead of Service to set the lifecycle of the service
        [UseFiltering] // Don't forget to add on configure services in Startup
        [UseSorting] // Don't forget to add on configure services in Startup
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context){
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        //[UseProjection]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context){
            return context.Commands;
        }
    }
}