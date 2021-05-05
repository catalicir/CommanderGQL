using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Commands{

    //this is the GraphQL wrapper around the generic model 
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command");
            
            descriptor
            .Field(p=>p.Platform)
            .ResolveWith<Resolvers>(p=>p.GetPlatform(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the platform for the command");
        }

        public class Resolvers {

            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context){
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }


        }
    }
}