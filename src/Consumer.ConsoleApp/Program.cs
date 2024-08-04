
using Consumer.ConsoleApp;
using Lorna;

var services = new ServiceCollection();

services.AddSingleton<IConsoleWriter, ConsoleWriter>();
services.AddSingleton<IIdGenerator, IdGenerator>();

var serviceProvider = services.BuildServiceProvider();

var idGenerator1 = serviceProvider.GetService<IIdGenerator>();
var idGenerator2 = serviceProvider.GetService<IIdGenerator>();

idGenerator1!.PrintId();
idGenerator2!.PrintId();