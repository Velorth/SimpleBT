# SimpleBT
SimpleBT is a lightweight implementation of behaviour trees for Unity. The main goal of the project is to simplify programming of non-player characters behaviour. 

The package provides several pre-defined most commonly used BT-nodes including composers and decorators such as sequences, selectors and loops.

## Prerequisites
The project has been tested in Unity 2019.3. 

## Installation
To install this package, add the following line to your `manifest.json` file located within your project's packages directory.

```json
"com.simpleproto.behaviourtrees": "git+https://github.com/Velorth/SimpleBT"
```

## Quick start
SimpleBT library is built around three concepts: behaviour tree nodes, execution context, and variables.

The behaviour tree is a hierarchical structure build from nodes of different types. 

A context is an object used to provide access to the globals state of the game world and the controlled character to the tree node. You have to define your own class for the context object that matches your needs and pass instance of this class as a parameter to ```Execute()``` method.

A variable is a container to store intermediate values. The variables are stored outside of the tree and they can be passed to the tree nodes as input or output parameters. 

Behaviour trees and variables can be defined in C# script in declarative style using object and collection initialization syntax.
 
```cs
void Start()
{
    // Create memory variables
    var moveTarget = new Variable<Vector3>();
    var waitTime = new Variable<float>();

    // Build tree
    _tree = new RepeatForever
    {
        new Sequence
        {
            new GetRandomPoint { Radius = 5, Output = moveTarget },
            new MoveTo { Target = moveTarget },
            new GetRandomFloat { Min = 0.5f, Max = 2f, Output = waitTime },
            new Wait { Time = waitTime}
        }
    };
}
```
To run behaviour tree the ```Execute``` method should be called. It accepts context as a parameter.
```cs
void Update()
{
    _tree.Execute(gameObject);
}
```

The execution context can be an object of any type. If BT-node expects some specific type and fail execution safely.

## Performance
SimpleBT tries to balance between performance and usability. 
It doesn't use generic dictionaries with string keys for blackboard memory and doesn't perform boxing valuetypes.
But it still relies on interfaces and virtual methods for extensibility and downcasts for safity.

## Future plans
1. Behavior tree debugging.
2. Visual designer (Not very soon).

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
