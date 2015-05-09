using System;
using System.Collections.Generic;

namespace Retro.Domain.Entities
{
    public class RetrospectiveFactory
    {
        public static Retrospective Create(string description) {
            return new Retrospective
                   {
                       Description = description,
                       Categories = new[]
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
                                    }
                   };
        }
    }
}