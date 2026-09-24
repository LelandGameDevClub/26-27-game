# Contributing

This guide assumes you have never used Git before. Follow it top to bottom the first time.

---

## 1. One-time setup

### Install the right Unity version

**Unity 6000.6.2f1**, installed through Unity Hub. If Unity offers to upgrade the project when you open it, **say no and ask a lead** — upgrading rewrites hundreds of files and breaks everyone else's checkout.

When adding the project in Unity Hub, select the **`Game/`** folder, not the repository root.

### Install Git LFS

Art and audio files are large and change often. Git LFS stores them efficiently so cloning stays fast. **Run this once per computer, before your first commit:**

```bash
git lfs install
```

If you commit a `.png` or `.wav` without LFS installed, the raw file is baked into the repo's history permanently and cannot easily be removed. If you think this happened, tell a lead rather than trying to fix it yourself.

### Turn on Unity Smart Merge

Two people editing the same scene produces a conflict that is impossible to resolve by hand — the file is thousands of lines of machine-generated YAML. Unity ships a tool that resolves these automatically. Point Git at it, **once per computer**:

**macOS**
```bash
git config --global merge.unityyamlmerge.name "Unity SmartMerge"
git config --global merge.unityyamlmerge.driver '/Applications/Unity/Hub/Editor/6000.6.2f1/Unity.app/Contents/Tools/UnityYAMLMerge merge -p %O %B %A %A'
```

**Windows**
```bash
git config --global merge.unityyamlmerge.name "Unity SmartMerge"
git config --global merge.unityyamlmerge.driver '"C:\Program Files\Unity\Hub\Editor\6000.6.2f1\Editor\Data\Tools\UnityYAMLMerge.exe" merge -p %O %B %A %A'
```

Adjust the path if you installed Unity somewhere else.

### Check your Unity settings

These should already be correct from `ProjectSettings/`, but verify under **Edit → Project Settings → Editor**:

- **Version Control → Mode:** `Visible Meta Files`
- **Asset Serialization → Mode:** `Force Text`

Without these, Unity writes unreadable binary files that Git cannot merge at all.

---

## 2. The workflow

### Always branch

```bash
git checkout main
git pull
git checkout -b code/dialogue-system
```

Branch names: `team/short-description`, all lowercase with dashes.

| Team | Prefix | Example |
|---|---|---|
| Story | `story/` | `story/act-1-outline` |
| Art | `art/` | `art/mayor-sprite` |
| Sound | `sound/` | `sound/town-theme` |
| Coding | `code/` | `code/dialogue-system` |

### Commit as you go

```bash
git add .
git commit -m "Add dialogue box that advances on spacebar"
```

Write messages that say what changed and why, in plain language. `"stuff"`, `"fix"`, and `"asdf"` help nobody in March.

### Push and open a Pull Request

```bash
git push -u origin code/dialogue-system
```

Then open a PR on GitHub, fill in the template, and request a review. A club lead merges it. **Nobody pushes directly to `main`** — `main` must always open in Unity and run.

### Pull often

Start every session with `git pull` on `main` before branching. Most painful conflicts come from a branch that sat untouched for two weeks.

---

## 3. Working on scenes and prefabs

Scenes are the one thing Git handles badly, so we handle it socially:

- **Claim a scene in Discord before you open it for editing.** Say which scene and roughly how long. Unclaim when you push.
- **Keep scene edits small and push the same day.** A scene branch that lives for a week will conflict.
- **Prefer prefabs over scene edits.** If you build your thing as a prefab, you edit the prefab file and everybody else's scene work stays untouched. This is the single best habit for avoiding conflicts.

If you get a scene conflict anyway and Smart Merge doesn't resolve it, **stop and ask a lead**. Do not hand-edit a `.unity` file.

---

## 4. Rules by team

### Story

- Write in Markdown in `docs/story/`. You can do this in a browser on GitHub — no Unity needed.
- One file per act, chapter, or character. Keep a running `characters.md` so art and sound know who they're designing for.
- When dialogue is final, tell the coding team so it can be turned into in-game dialogue data.

### Art / Design

- Export game-ready sprites as `.png` with transparency into the right `Art/` subfolder. Commit the working file (`.aseprite`, `.psd`) next to it so someone else can revise it.
- Agree on a **pixels-per-unit** value and canvas sizes with the coding team early, and write it down in `docs/art/`. Changing it later means re-slicing everything.
- Never delete or rename someone else's art without asking — Unity tracks files by their `.meta`, and renaming outside Unity breaks every reference to it. **Rename inside the Unity Editor**, which moves the `.meta` too.

### Sound

- Compose in FL Studio, then export to `.wav` for short sounds and `.ogg` for long music tracks.
- Commit the exported audio **and** the `.flp` project file, so someone else can pick up the track.
- Name by role, not by mood: `Music_TownSquare.wav`, `SFX_DoorOpen.wav`.
- Keep loops actually loopable, and tell the coding team which tracks are meant to loop.

### Coding

- C# only. One class per file, file name matches the class name.
- Use `PascalCase` for classes, methods, and public fields; `camelCase` for local variables; `_camelCase` for private fields. Match the surrounding code when in doubt.
- Put shared, tunable values (speeds, damage, dialogue text) in `ScriptableObject` assets under `Data/` or in serialized fields, so designers and writers can change them in the Inspector without editing code.
- Comment *why*, not *what*. `// jump feels floaty below 12` is useful; `// set speed to 12` is not.
- Before opening a PR, make sure the game actually enters Play Mode with no console errors.

---

## 5. Things that break the repo

Ask before doing any of these:

- Changing anything in `ProjectSettings/` (physics, layers, tags, input, quality)
- Upgrading the Unity version
- Adding or removing a package in `Packages/manifest.json`
- Renaming or moving files **outside** the Unity Editor
- Committing the `Library/` folder (it's ignored — if you see it in `git status`, stop and ask)
- Force-pushing anything (`git push --force`)

---

## 6. When something goes wrong

Nothing here is unfixable, and no one is in trouble for breaking something. The only way to make it worse is to keep committing on top of it.

1. Stop.
2. Don't force-push.
3. Post in Discord with what you ran and what it said.
