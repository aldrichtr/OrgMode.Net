---
description: 'Instructions for the OrgMode.Net project.'
applyTo: '*'
---

# OrgMode.Net Instructions

OrgMode.Net is a C# library for parsing and working with Org mode files. It provides a robust and efficient way to
handle Org mode syntax, making it easier to integrate Org mode functionality into .NET applications.

## Emacs-lisp parser source code
Emacs` parser is the original, de-facto parser for org-mode formatted text.  Its source code is copied to the local file
`docs/emacs-source/org-element.el`

## General Instructions

- The canonical reference for Org mode syntax is the [Org syntax](https://orgmode.org/worg/org-syntax.html).
- Divide the code into logical components, each responsible for a specific aspect of Org mode parsing or manipulation.
  - Separate syntax elements into their own classes or structs.
  - Use interfaces to define common behaviors for different syntax elements.
  - Separate parsing logic into the Parser namespace.
  - Separate rendering logic into the Renderer namespace.

# Org Syntax structure

These Elements were extracted from `org-element.el` file

# Greater Elements

  ELisp Name            .Net Name            Notes
  --------------------- -------------------- -------
  center-block          CenterBlock
  drawer                Drawer
  dynamic-block         DynamicBlock
  footnote-definition   FootnoteDefinition
  headline              Headline
  inlinetask            Inlinetask
  item                  Item
  plain-list            PlainList
  property-drawer       PropertyDrawer
  quote-block           QuoteBlock
  section               Section
  special-block         SpecialBlock
  table                 Table
  org-data              OrgData

  : Greater Elements

# Lesser Elements

  ELisp Name          .Net Name          Notes
  ------------------- ------------------ -------
  babel-call          BabelCall
  clock               Clock
  comment             Comment
  comment-block       CommentBlock
  diary-sexp          DiarySexp
  example-block       ExampleBlock
  export-block        ExportBlock
  fixed-width         FixedWidth
  horizontal-rule     HorizontalRule
  keyword             Keyword
  latex-environment   LatexEnvironment
  node-property       NodeProperty
  paragraph           Paragraph
  planning            Planning
  src-block           SrcBlock
  table-row           TableRow
  verse-block         VerseBlock

  : Lesser Elements

# Objects

  ELisp Name           .Net Name           Notes
  -------------------- ------------------- -------
  bold                 Bold
  citation             Citation
  citation-reference   CitationReference
  code                 Code
  entity               Entity
  export-snippet       ExportSnippet
  footnote-reference   FootnoteReference
  inline-babel-call    InlineBabelCall
  inline-src-block     InlineSrcBlock
  italic               Italic
  line-break           LineBreak
  latex-fragment       LatexFragment
  link                 Link
  macro                Macro
  radio-target         RadioTarget
  statistics-cookie    StatisticsCookie
  strike-through       StrikeThrough
  subscript            Subscript
  superscript          Superscript
  table-cell           TableCell
  target               Target
  timestamp            Timestamp
  underline            Underline
  verbatim             Verbatim

  : Objects
