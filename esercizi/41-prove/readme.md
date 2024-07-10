``` mermaid
---
title: Menu principale
---
stateDiagram-v2
    [*] --> "Inserimento di nomi in lista"
    Still --> [*]

    Still --> Moving
    Moving --> Still
    Moving --> Crash
    Crash --> [*]

```