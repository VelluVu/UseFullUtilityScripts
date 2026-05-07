# Useful Utility Scripts

> A personal collection of reusable Unity C# utility scripts.

![Unity](https://img.shields.io/badge/Engine-Unity-black?logo=unity) ![Language](https://img.shields.io/badge/Language-C%23-purple)

## About

A collection of small but handy Unity C# scripts that solve common, recurring problems in game development. Rather than rewriting these from scratch in every project, they're kept here as a personal toolkit to drop into any Unity project.

## Scripts Included

- **Singleton.cs** — Generic MonoBehaviour singleton base class
- **ObjectPooler.cs** — Simple object pooling system for performance
- **Timer.cs** — Countdown and stopwatch utility
- **CameraShake.cs** — Screen shake effect with configurable intensity
- **ExtensionMethods.cs** — Handy C# extension methods (Vector3, string, etc.)
- **SceneLoader.cs** — Async scene loading with loading screen support
- **AudioManager.cs** — Simple audio manager for SFX and music
- *(Add more as applicable based on actual repo contents)*

## Usage

Copy any script into your Unity project's `Assets/Scripts/` folder and attach to a GameObject, or call statically where applicable.

Example — using the Timer:
```csharp
Timer countdown = new Timer(30f);
countdown.Start();

void Update() {
    if (countdown.IsFinished) {
        Debug.Log("Time's up!");
    }
}
```

## Contributing

If you find a bug or want to add a utility, feel free to open a PR.

## Context

Accumulated over years of Unity game development projects. Having a personal utility library is a good habit — it speeds up prototyping and keeps common patterns consistent across projects.
