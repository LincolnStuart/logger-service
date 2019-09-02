# Logger Service
It's a simple Windows Service example.
To run this example you need to create a service on your OS.
- First step is compiling your project to generate an *.exe*.
- Then you need open your *prompt* as *admin*.
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
