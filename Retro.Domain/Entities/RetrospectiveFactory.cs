using System;
using System.Collections.Generic;

namespace Retro.Domain.Entities
{
    public class RetrospectiveFactory
    {
        public static Retrospective Create(string description, string template) {
            return new Retrospective
                   {
                       Description = description,
                       Categories = CreateCategories(template)
                   };
        }

        private static RetrospectiveItemCategory[] CreateCategories(string template) {
            switch (template) {
                case "1": {
                    return new[]
                           {
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "TODO",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(125, 67%, 72%, 1)"
                               }
                           };
                }

                case "2": {
                    return new[]
                           {
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "Pros",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(125, 67%, 72%, 1)"
                               },
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "Cons",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(125, 67%, 72%, 1)"
                               }
                           };
                }

                case "3": {
                    return new[]
                           {
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "What went well?",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(125, 67%, 72%, 1)"
                               },
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "What needs to be improved?",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(360, 67%, 72%, 1)"
                               },
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "What should be tried next?",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(225, 67%, 72%, 1)"
                               }
                           };
                }
                case "4": {
                    return new[]
                           {
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "Section 1",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(125, 67%, 72%, 1)"
                               },
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "Section 2",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(360, 67%, 72%, 1)"
                               },
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "Section 3",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(225, 67%, 72%, 1)"
                               },
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "Section 4",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(225, 67%, 72%, 1)"
                               }
                           };
                }
                default:
                    return new[]
                           {
                               new RetrospectiveItemCategory
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CreatedOn = DateTime.UtcNow,
                                   UpdatedOn = DateTime.UtcNow,
                                   Description = "TODO",
                                   Items = new List<RetrospectiveItem>(),
                                   Color = "hsla(125, 67%, 72%, 1)"
                               }
                           };
                    ;
            }
        }
    }
}