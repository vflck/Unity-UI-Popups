# 💬 Unity UI Popups

This small package is a solution for **UI Popups in Unity**:
- 🚀Quick to set up
- ▶️Large number of **Easings**
- ✔️Has three main popups _(Fade, Scale, Move)_

### How To Install?
Download it and import `.unitypackage` file to your project!
> or just copy the code as needed.

### How To Use?
- Add a component to your UI window and configure it as you wish:
\
`Add Component -> UI Popup ->` and the **popup** you need.

- Then just get a reference to your popup in scene and use the method `Show()`, passing a boolean to it:
```csharp
[SerializeField] private BasePopupUI somePopup;

somePopup.Show(true);   // for showing
somePopup.Show(false);  // for hiding
```

\
_I hope you found this useful! Comments and advice are welcome!_