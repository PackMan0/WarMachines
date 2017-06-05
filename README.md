# War Machines

There are two types of **machines** : **tanks** and **fighters**. Each machine has **name** , **pilot** , **health points** , **attack points** , **defense points** and **attack targets**. Each pilot has **name** and **machines** he **engages**. Pilots make status **reports** on all machines they engage. One machine can be **engaged** by one pilot at a time.   **Tanks** have **defense mode** which can be turned **on** and **off**. **Fighters** have stealth mode which can be turned **on** and **off**.

### Design the Class Hierarchy

Your **task** is to **design an object-oriented class hierarchy** to model the war machines factory, machines and pilots **using the best practices for object-oriented design (OOD) and object-oriented programming (OOP)**. Avoid duplicated code though abstraction, inheritance, and polymorphism and encapsulate correctly all fields.

Tank&#39;s initial health points are always 100 and fighter&#39;s initial health points are always 200. Tank&#39;s defense mode adds 30 defense points to the initial ones and removes 40 attack points from the initial ones. By default tanks&#39; defense mode is turned on. Fighters in stealth mode can be attacked only by other fighters.

The attack targets added to a certain machine (though the **Attack(…)** method) should appear in the order of their addition. It is allowed to attack one machine (thus adding it) more than once. If the machine has no targets added to it, print &quot; **None**&quot;. Do not print **,** **(comma)** at the line end. All double type fields should be printed &quot; **as is**&quot;, without any formatting or rounding.

### Additional Notes

Current implemented commands the engine supports are:

- **HirePilot (name)** – adds a pilot with given name. Duplicate names are not allowed. As a result the command returns &quot;**Pilot (name) hired**&quot;.
- **Report (name)** – searches for a hired pilot with given name and returns the **IPilot.Report()** method result.
- **ManufactureTank (name) (attack) (defense)** – creates a tank with given name, attack and defense points.  Duplicate names are not allowed. Initial health points are always 100. Initial defense mode is turned on. As a result the command returns &quot;**Tank (name) manufactured - attack: (attack); defense: (defense)**&quot;.
- **DefenseMode (name)** – searches for tank with given name and toggles its defense mode. As a result the command returns &quot;**Tank (name) toggled defense mode**&quot;.
- **ManufactureFighter (name) (attack) (defense) (stealth)** – creates a fighter with given name, attack and defense points. Duplicate names are not allowed. Initial health points are always 200. As a result the command returns **&quot;Fighter (name) manufactured - attack: (attack); defense: (defense); stealth: (ON/OFF)&quot;**
- **StealthMode (name)** - searches for fighter with given name and toggles its stealth mode. As a result the command returns &quot;**Fighter (name) toggled stealth mode**&quot;.
- **Engage (pilot-name) (machine-name)** – searches for a pilot and machine by given names, adds the machine to the pilot&#39;s list of machines and initialises the machine&#39;s pilot. As a result the command returns &quot;**Pilot (pilot-name) engaged machine (machine-name)**&quot;.
- **Attack (attacking-machine-name) (defending-machine-name)** – searches for two machines by given names and the first one attacks the second one if it is possible. As a result the command returns &quot;**Machine (defending-machine-name) was attacked by machine (attacking-machine-name) - current health: (defending-machine-health).**

In case of invalid operation or error, the engine returns appropriate text messages.



### Sample 

| Input  | Output  |
| ------------ | ------------ |
|HirePilot John|Pilot John hired|
|HirePilot Nelson |Pilot Nelson hired|
|Report Bender|Pilot Bender could not be found|
|ManufactureTank T-72 100 100 |Tank T-72 manufactured - attack: 100; defense: 100|
|ManufactureFighter Kingcobra 150 90 StealthON|Fighter Kingcobra manufactured - attack: 150; defense: 90; stealth: ON|
|Report John |John - no machines|
|Engage John T-72|Pilot John engaged machine T-72|
|Engage John Kingcobra |Pilot John engaged machine Kingcobra|
|Report John|John - 2 machines - T-72 Type: Tank Health: 100 Attack: 60 Defense: 130 Targets: None Defense: ON - Kingcobra Type: Fighter Health: 200 Attack: 150 Defense: 90 Targets: None Stealth: ON|
|Report Nelson | Nelson - no machines|
|Engage Nelson T-72|Machine T-72 is already occupied|
|Engage Nelson Kingcobra |Machine Kingcobra is already occupied|
|ManufactureFighter Boeing 180 90 StealthOFF|Fighter Boeing manufactured - attack: 180; defense: 90; stealth: OFF|
|Engage Nelson Boeing |Pilot Nelson engaged machine Boeing|
|Attack T-72 Kingcobra|Tank T-72 cannot attack stealth fighter Kingcobra|
|Attack T-72 Boeing |Machine Boeing was attacked by machine T-72 - current health: 200|
|DefenseMode T-72|Tank T-72 toggled defense mode|
|DefenseMode Kingcobra |Machine Kingcobra does not support this operation|
|DefenseMode Boeing|Machine Boeing does not support this operation|
|Attack T-72 Kingcobra |Tank T-72 cannot attack stealth fighter Kingcobra|
|Attack T-72 Boeing|Machine Boeing was attacked by machine T-72 - current health: 190|
|StealthMode Kingcobra |Fighter Kingcobra toggled stealth mode|
|StealthMode Boeing|Fighter Boeing toggled stealth mode|
|StealthMode T-72 |Machine T-72 does not support this operation|
|Attack Kingcobra T-72|Machine T-72 was attacked by machine Kingcobra - current health: 50|
|Attack Boeing T-72 |Machine T-72 was attacked by machine Boeing - current health: 0|
|Report Nelson|Nelson - 1 machine - BoeingType: Fighter Health: 190 Attack: 180 Defense: 90 Targets: T-72 Stealth: ON |
|Report John|John - 2 machines - T-72 Type: Tank Health: 0 Attack: 100 Defense: 100 Targets: Boeing, Boeing Defense: OFF - Kingcobra Type: Fighter Health: 200 Attack: 150 Defense: 90 Targets: T-72 Stealth: OFF|
