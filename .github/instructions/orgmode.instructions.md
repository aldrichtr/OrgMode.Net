---
description: 'Instructions for the OrgMode.Net project.'
applyTo: '*'
---

# OrgMode.Net Instructions

OrgMode.Net is a C# library for parsing and working with Org mode files. It provides a robust and efficient way to handle Org mode syntax, making it easier to integrate Org mode functionality into .NET applications.

## General Instructions

- The canonical reference for Org mode syntax is the [Org syntax](https://orgmode.org/worg/org-syntax.html).
- Divide the code into logical components, each responsible for a specific aspect of Org mode parsing or manipulation.
  - Separate syntax elements into their own classes or structs.
  - Use interfaces to define common behaviors for different syntax elements.
  - Separate parsing logic into a the Parser namespace.
  - Separate rendering logic into a the Renderer namespace.
