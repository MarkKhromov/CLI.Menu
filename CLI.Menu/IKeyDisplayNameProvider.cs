using System;

namespace CLI.Menu {
    public interface IKeyDisplayNameProvider {
        string GetDisplayName(ConsoleKey? key);
    }
}