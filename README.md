#Serilog.Sinks.TextWriter

The System.IO.TextWriter sink for Serilog.

[![Build status](https://ci.appveyor.com/api/projects/status/rkbgynaaav6g6789?svg=true)](https://ci.appveyor.com/project/serilog/serilog-sinks-textwriter) [![NuGet Version](http://img.shields.io/nuget/v/Serilog.Sinks.TextWriter.svg?style=flat)](https://www.nuget.org/packages/Serilog.Sinks.TextWriter/)

Writes to a specified `System.IO.TextWriter` and can thus be attached to practically any text-based .NET output and the in-memory `System.IO.StringWriter` class.

```csharp
var messages = new StringWriter();

var log = new LoggerConfiguration()
    .WriteTo.TextWriter(messages)
    .CreateLogger();
```

* [Documentation](https://github.com/serilog/serilog/wiki)

Copyright &copy; 2016 Serilog Contributors - Provided under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html).
