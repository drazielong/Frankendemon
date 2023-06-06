INCLUDE globals.ink
~ correct_power = "Ana"
{power_name == correct_power: -> unblocked}
-> blocked

=== blocked ===
{ana_met == false:
These things are blocking the way. #speaker:Noxie #portrait:invis #player portrait:noxie_neutral #layout:left

I know someone who works at Body Building who can probably help... #speaker:Dearil #portrait:dearil_shy #layout:right

Are they gonna rip them out of the ground? #speaker:??? #player portrait:noxie_thinking #layout:left
}
{ana_met == true:
Ugh more of these plants... #speaker:Noxie #portrait:invis #player portrait:noxie_neutral #layout:left
}
->END

=== unblocked ===
Using Ana's power, you're able to see through the plants and find their weakpoint. #layout:none #portrait:invis #player portrait:invis
Touching it causes the foliage to retract into the ground.
Hey, this is pretty cool! #speaker:Noxie #portrait:invis #player portrait:noxie_laugh #layout:left
I mean- #player portrait:noxie_nervous
Uh it's alright... #player portrait:noxie_neutral
->END