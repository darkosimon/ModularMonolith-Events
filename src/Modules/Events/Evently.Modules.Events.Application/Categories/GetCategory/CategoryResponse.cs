using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evently.Modules.Events.Application.Categories.GetCategory;
public sealed record CategoryResponse(Guid Id, string Name, bool IsArchived);
