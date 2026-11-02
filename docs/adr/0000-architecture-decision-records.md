# Architecture Decision Records 

* Deciders: @SzymonFrac
* Last updated: 2026-11-02

## Status

Accepted

## Context and Problem Statement

Throughout the development of FileCompositions, many internal decisions on past architecture problems are lost.\
Decisions which shape the model of the solution and explain the ideas rather than the implementation.\
The project needs a consistent history of architecture development to be used as a reference for future decisions.

## Decision Outcome

The project will start documenting architecture decisions with ADRs.\
ADRs hope to provide a history of FileCompostions development, to be used as references for new ideas and new collaborators.\
They should be short and to the point, while providing sufficient context for the problem and solution to be clear.

### Conventions

MADR will be the default format.\
`./docs/adr` will be the default storage path.\
`adr.config.json` at the root of the repo provides config, including default path and (possibly) template.

ADRs will stay on the development branch `develop/vx` during development. Then, merged to `master` once released.\
Relevant ADRs will be commited alongside refactors (`refactor/`) in PRs if required.

#### Positive Consequences

* Architecture rationale is preserved over time
* Collaborators have a source of truth to understand the architecture intent
* The source of truth is applied to the development branch viewed; which explains the rationale on that version

#### Negative Consequences

* Small documentation overhead to architectural changes
* May require periodic reviews to keep the collection trustworthy

#### Neutral Consequences

* The `master` branch isn't the single source of truth for the entire project, but for the most recent stable version.