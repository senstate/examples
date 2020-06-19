# Godot + Senstate

## Installation:

1. Add these lines to your `packages.config`
```xml
  <package id="Newtonsoft.Json" version="12.0.3" targetFramework="net472" />
  <package id="Senstate.CSharp-Client" version="0.1.0" targetFramework="net472" />
  <package id="Senstate.NetStandard" version="0.1.0" targetFramework="net472" />
```

2. Follow the examples in: https://github.com/senstate/csharp-client

3. Happy Debugging


Notes:
- Dont spam the watchers while in Update() :)
- If you restarting the app, maybe add a `AppId` that way you won't loose your last app state... or if you want to do that, then ignore this note :)
