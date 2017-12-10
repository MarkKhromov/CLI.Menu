using System;

namespace CLI.Menu {
    public interface IKeyDisplayNameProvider {
        string GetDisplayName(ConsoleKey? key);
        string MenuTitle { get; }
        string NextButtonText { get; }
        string BackButtonText { get; }
        string ExitButtonText { get; }
    }
}