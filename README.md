# Bouncy Arcade Vehicle
 My attempt at a simplistic arcade off-road vehicle. 
Arcade Car Physics: Bouncy Off-Road 4x4


Objective: Imitate some old 90’s presentation of 
a bouncy cart like suspension
Inspirations: My love for arcade racing games,
Twisted Metal , Hard Truck Apocalypse, Motorstorm??
Features:
   Simple Friction Model 
   Basic traction model – loses traction when car is airborne or turns at speed
   Reasonable Suspension model
   Vehicle rights itself when flipped over
Challenges:
	Determining the right way to handle slopes
		Various methods have been exhausted but when remains on the right track- Utilizing the dot product on the ray hit normal if the angle is greater or less then up direction of the force is either vector3.up, on the wheel local up coordinate or the wheel ray hit normal.

What needs to be done:
   Finish and refactor vehicle suspension
   Implement friction and traction
  Allow Vehicle to be controlled
  Allow to reset the vehicle
   Implement vehicle righting
