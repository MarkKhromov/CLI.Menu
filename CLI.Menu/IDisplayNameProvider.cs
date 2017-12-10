using System;

namespace CLI.Menu {
    public interface IDisplayNameProvider {
        string GetDisplayName(ConsoleKey? key);
        string MenuTitle { get; }
        string NextDisplayName { get; }
        string BackDisplayName { get; }
        string ExitDisplayName { get; }
    }
}