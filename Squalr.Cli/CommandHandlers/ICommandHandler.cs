﻿namespace Squalr.Cli
{
    using Squalr.Engine;

    public interface ICommandHandler
    {
        void TryHandle(ref Session session, Command command);
    }
    //// End class
}
//// End namespace
