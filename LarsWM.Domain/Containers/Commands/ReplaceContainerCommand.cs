﻿using System.Collections.Generic;
using LarsWM.Infrastructure.Bussing;

namespace LarsWM.Domain.Containers.Commands
{
  public class ReplaceContainerCommand : Command
  {
    public Container ParentContainer { get; }
    public int ChildIndex { get; }
    public List<Container> ReplacementContainers { get; }

    public ReplaceContainerCommand(Container parentContainer, int childIndex, List<Container> replacementContainers)
    {
      ParentContainer = parentContainer;
      ChildIndex = childIndex;
      ReplacementContainers = replacementContainers;
    }
  }
}