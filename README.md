# Leland Game Design Club — 2026–2027 Game

The club's game for the 2026–2027 school year, built in **Unity 6 (6000.6.2f1)** with **C#** and the **Universal Render Pipeline (2D)**.

> **Working title:** _TBD_ — replace this line once the team picks a name.

---

## New here? Start in three steps

1. **Install Unity Hub**, then install Unity **6000.6.2f1** exactly. A different version will silently upgrade the project files and create conflicts for everyone else.
2. **Read [CONTRIBUTING.md](CONTRIBUTING.md)** and run the two one-time setup commands in it (Git LFS and Unity Smart Merge). Do this *before* your first commit — it prevents the two problems that break Unity repos most often.
3. **Open the project**: in Unity Hub choose *Add project from disk* and select the **`Game/`** folder (not the repo root).

---

## Teams

Everyone works in one of four areas, and **all four coordinate with each other** — a character is a drawing, a personality, a set of sounds, and a set of scripts at the same time.

| Team | What you make | Where it lives |
|---|---|---|
| **Story writing** | Plot, events, dialogue, character bios | [`docs/story/`](docs/story/) |
| **Art / Design** | Characters, buildings, environments, UI | [`Game/Assets/_Project/Art/`](Game/Assets/_Project/Art/) |
| **Sound** | Music and sound effects (primarily FL Studio) | [`Game/Assets/_Project/Audio/`](Game/Assets/_Project/Audio/) |
| **Coding** | C# gameplay code, systems, tools | [`Game/Assets/_Project/Scripts/`](Game/Assets/_Project/Scripts/) |

Writers and designers don't need Unity installed to contribute — `docs/` is plain Markdown you can edit on GitHub in a browser.

---

## Repository layout

```
26-27-game/
├── Game/                          # The Unity project — open THIS folder in Unity Hub
│   ├── Assets/
│   │   ├── _Project/              # Everything the club makes
│   │   │   ├── Animations/        # Animation clips, Animator controllers
│   │   │   ├── Art/               # Characters, Environment, UI, VFX, Tilesets
│   │   │   ├── Audio/             # Music, SFX
│   │   │   ├── Data/              # ScriptableObjects: dialogue, items, levels
│   │   │   ├── Prefabs/           # Reusable configured GameObjects
│   │   │   ├── Scenes/            # Levels and menus
│   │   │   └── Scripts/           # C# — Player, Systems, Dialogue, UI, Utilities
│   │   ├── Settings/              # Unity-generated URP + Input System settings
│   │   └── Welcome/               # Unity's 2D template sample — safe to delete later
│   ├── Packages/                  # Package manifest (dependencies)
│   └── ProjectSettings/           # Project-wide settings — change only with a lead's OK
├── docs/                          # Written design docs — story, design, art, audio
├── .github/                       # PR and issue templates
├── .gitattributes                 # Git LFS + Unity scene merging
└── CONTRIBUTING.md                # Setup, workflow, and rules — read this
```

Every folder has its own `README.md` explaining what belongs in it.

---

## Naming rules

Consistent names make things findable and stop merge conflicts. Use `PascalCase` everywhere, with no spaces.

| Kind | Pattern | Example |
|---|---|---|
| C# script | `PascalCase.cs`, name matches the class | `PlayerMovement.cs` |
| Scene | `PascalCase` | `TownSquare.unity` |
| Prefab | `PascalCase` | `PlayerCharacter.prefab` |
| Sprite | `Subject_Variant` | `Mayor_Idle.png`, `Mayor_Walk_01.png` |
| Music | `Music_Place` | `Music_TownSquare.wav` |
| Sound effect | `SFX_Thing` | `SFX_DoorOpen.wav` |
| Story doc | `kebab-case.md` | `act-1-outline.md` |

---

## Everyday workflow

Never commit straight to `main`. `main` must always open and run.

```bash
git checkout main
git pull                          # always start from the latest
git checkout -b art/mayor-sprite  # yourname or team/short-description
# ...do your work in Unity...
git add .
git commit -m "Add mayor idle and walk sprites"
git push -u origin art/mayor-sprite
```

Then open a Pull Request on GitHub. A club lead reviews and merges it.

Full details — branch naming, scene claiming, LFS, and what to do when Unity conflicts — are in **[CONTRIBUTING.md](CONTRIBUTING.md)**.

---

## Getting help

Stuck for more than ~20 minutes? Ask in the club Discord or open an [issue](../../issues). Being stuck quietly is the only real mistake.
