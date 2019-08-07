# Logger Service
It's a simple Windows Service example.
To run this example you need create a service on your OS.
- First step is compiling your project to generate an *.exe*.
- Then you need open your *prompt* as *admin*.
- In your prompt go to your project folder using *cd*.
  ex.: 
```
cd C:\Users\lincoln\source\repos\Service\Service\bin\Debug\netcoreapp2.1
```
- Create a service on your Windows.
  ex.:
```
sc create [service name] binpath=[full path to binary]
```
- Start your service.
  ex.:
```
sc start [service name]
```
