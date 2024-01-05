# DressUpDemoGame
This repository includes Unity project files for the game development portion and Windows build files, including the executable (exe) file for running the game on Windows.

## Overview
This demo introduces a character dressing project that can be seen in various types of games, ranging from smaller to larger ones. It's designed in 3D, and the outfits are created on Blender. The main goal of this demo is to showcase the ability to change outfits. Although the models we got from Blender may not make the character look super fancy, they still allow the character to put on different clothes.

**Important Note:**
The character and animations were acquired from Mixamo, so the showcased outfits in the project essentially dress the character with the original attire from Mixamo's model. This implies that the character's initial clothes, referred to as the base attire, cannot be altered.

As illustrated below is an image of the model:
![1](https://github.com/irfanSOLAK/DressUpDemoGame/assets/108720676/04cfe00d-e747-4909-b111-d985d41c7fcc)

## Gameplay
The game allows you to drag and drop outfits, but dressing your character is as simple as clicking on the attire in the menu. Game Menu provides a convenient way to access a diverse range of outfits, organized into three distinct tabs: 'tops,' 'bottoms,' and 'full body.' Users can effortlessly switch between these tabs, each dedicated to specific clothing categories. The second tab, as depicted in the image below, displays the available options.
![2](https://github.com/irfanSOLAK/DressUpDemoGame/assets/108720676/cca9ff50-0eb4-4c44-b952-4c1264159fb6)

Importantly, this transition feature doesn't reset selected outfits, allowing for the simultaneous wearing of 'tops' and 'bottoms.' However, when opting for a 'full body' outfit, other clothing items are automatically removed.
![12](https://github.com/irfanSOLAK/DressUpDemoGame/assets/108720676/3246c8ac-d393-42ef-aeea-f813767c22cf)

When a full body outfit is worn, others will be removed.
![10](https://github.com/irfanSOLAK/DressUpDemoGame/assets/108720676/35f3a60c-a151-4343-a726-f29d5fb79d4c)


When you click the button, the character will wear the chosen outfit smoothly. You can also dress it up by dragging and dropping. If the outfit is dragged outside the menu, its image disappears, and a 3D model takes its place. The model always matches the character's rotation. Right-clicking makes the character spin around, and if there's an outfit selected, it will spin too.

The clothing image can be dragged.
![4](https://github.com/irfanSOLAK/DressUpDemoGame/assets/108720676/185cca46-ccc3-466b-b84e-02debdebd774)

The transition between the image and the 3D cloth model.
![5](https://github.com/irfanSOLAK/DressUpDemoGame/assets/108720676/bd9d4cf6-a78e-41e2-b7eb-91b85486d4c8)

The 3D cloth model.
![6](https://github.com/irfanSOLAK/DressUpDemoGame/assets/108720676/157a8600-bf77-4f15-936e-a7eaf6b26bfa)

The cloth is worn.
![8](https://github.com/irfanSOLAK/DressUpDemoGame/assets/108720676/9497bfd3-7ed8-4fb1-b4b0-e28ca648a53a)

The selected outfit and character rotation can be controlled with a right-click and will always be the same.
![11](https://github.com/irfanSOLAK/DressUpDemoGame/assets/108720676/c4d57137-cda0-493c-b28e-5c46d1cc7b87)

# Technical Highlights
## Design Patterns Implementation:
•	**Singleton:** Utilizing a robust Singleton structure, objects seamlessly acquire this feature when necessary. The project incorporates a GameManager, named GameBehaviour, demonstrating the effective implementation of this pattern.

•	**Observer:** The Observer design pattern is skillfully implemented using a subscription model. Managed by the Notification Manager script, this pattern allows objects to register and unregister for events denoted by enums. Objects, derived from a listener base class, attentively listen to these events.

## SOLID Principles Adherence:
The codebase strictly adheres to SOLID principles, ensuring a robust and maintainable architecture.

## Clean Code Practices:
The implementation follows clean code practices, promoting readability and facilitating a streamlined and efficient development process.

## GameManager
The GameManager serves as a pivotal component, streamlining communication between objects and optimizing the architecture for clarity and maintainability.

## Functionality Approach
The CharacterEquip script functions by recording the bone structure of the character. Simultaneously, it includes the bones within the regions covered by the outfits, maintaining identical names and ordering. This mechanism enables the script to effectively synchronize the bones of the outfits with those of the character, facilitating the process of outfitting. This operational approach ensures a seamless interaction between the script and the game mechanics, providing a reliable method for dressing characters based on the alignment of bones from both the character and the outfits.

## Untiy version
2020.3.35f1
