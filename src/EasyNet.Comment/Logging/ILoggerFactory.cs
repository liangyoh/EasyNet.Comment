﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNet.Comment.Logging
{
    /// <summary>Represents a logger factory.
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>Create a logger with the given logger name.
        /// </summary>
        ILogger Create(string name);
        /// <summary>Create a logger with the given type.
        /// </summary>
        ILogger Create(Type type);
    }
}
