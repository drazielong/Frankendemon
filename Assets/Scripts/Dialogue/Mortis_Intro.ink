INCLUDE globals.ink
{mortis_completed == true: -> helloagain}
{has_rawEssence: -> essence}
{mortis_met == true: -> instructions}
Hi! Hello! Salutations! #speaker:Mortis #portrait:mortis_happy #layout:right #player portrait:noxie_neutral #companion portrait:invis
I see that you've already started walking, so why don't we hurry along with the readjustment period? #layout:right
How are those relatively new limbs treating you?
...Where am I? What happened to me? #speaker:??? #layout:left #player portrait:noxie_confused
Oh my. #speaker:Mortis #layout:right #companion portrait:invis
Oh my my my
This. 
Is absolutely. 
<color=\#71eb6b>WONDERFUL!!!
Already able to speak?! You're already faring better than my previous attempts! 
Let us skip ahead to the cognitive tests, then! 
Can you count to five for me? How many fingers am I holding up?
One, two, three, four, five? #speaker:??? #layout:left
~ typing_speed = 0.04 
Uh, three fingers...
~ typing_speed = 0.02
Wait 
Why am I doing this. #player portrait:noxie_sigh
Who even are you.
This is a major breakthrough! #speaker:Mortis #layout:right
You're talking back, thinking for yourself, asking QUESTIONS!
I believe I may have finally done it! 
DONE WHAT?! #speaker:??? #layout:left #player portrait:noxie_angry
Why, necromancy of course! #speaker:Mortis #layout:right
But not just any necromancy, no no no we are not so simple here. 
<i>Trans-species</i> necromancy!
I caught your faint little human soul and reengineered it for a demon's body. 
Obviously this body is made up of multiple different long passed demons, not a single uniform body because believe it or not it's hard to find one whole, put together, BODY in the DECAY domain of all places,
Wait, I DIED??? #speaker:??? #layout:left #player portrait:noxie_angry
Like, all the way? 
Well, sure. How else would I have gotten your soul? By extracting it directly? #speaker:Mortis #layout:right
That’s preposterous. 
??? #speaker:??? #layout:left #player portrait:noxie_confused
//Uh, that doesn’t sound any more crazy than anything else you just told me… #speaker:??? #layout:left #player portrait:noxie_sigh
//Bah, I say do not dwell on the past. You cannot change what you cannot change. #speaker:Mortis #layout:right
//All of the action is right here in the present, and our potential in our future!

So basically I'm not human anymore...
I should hate you #player portrait:noxie_angry
But honestly #player portrait:noxie_thinking
this new body is way stronger than my old one
Way better, and
more comfortable?
...
You. #player portrait:noxie_neutral
Tell me how to get back to the human world.

Why would you ever want to do that? #speaker:Mortis #layout:right

I have some unfinished business I need to take care of. #speaker:??? #layout:left

If you ask me, whatever's there should stay there. It's much nicer here. #speaker:Mortis #layout:right

... #speaker:??? #layout:left

Well, if you MUST insist... #speaker:mortis #layout:right
I SUPPOSE I could aid you on this journey, but in exchange you must do something for me!
IF you happen to encounter any demon essences along the way, bring them back to me.

I don't even know what those things are. #speaker:??? #layout:left

You will know it when you see it! #speaker:mortis #layout:right
My assistant will accompany you.

Hello, that's me... #speaker:dearil #portrait:dearil_shy

I don't need a babysitter. Or to be a babysitter. Whatever. #speaker:??? #layout:left #portrait:mortis_happy
Just tell me the way to go.

You see, Dearil is both my insurance AND your guide to this world. #speaker:mortis #layout:right
I could point you in the right direction, but it will only get you so far.

... #speaker:??? #layout:left
Whatever. Which way.

After you exit my tower, go right. You will find yourself on a road that takes you to the next domain. #speaker:Mortis #layout:right
Farewell, and don't forget! Bring me essences!
~ mortis_met = true
->END

=== instructions ===
//Er... what was I supposed to do again? #speaker:??? #portrait:mortis_happy #layout:left #player portrait:noxie_confused
I will be waiting for you to return with an essence! #speaker:Mortis #portrait:mortis_happy #layout:right #player portrait:noxie_neutral
->END

=== essence ===
I see you've found an essence from someone!#speaker:Mortis #portrait:mortis_happy #layout:right #player portrait:noxie_neutral
As I suspected, you can't interact with it as demons normally would.
Allow me.

(Mortis inserts the essence into some kind of machine. It groans and creaks as it processes it.) #portrait:invis #player portrait:invis #companion portrait:invis #layout:none
(Eventually it finishes the task and a glass tube opens up to reveal a pair of arms.)

Voila! These are now yours to attach at will. #portrait:mortis_happy #player portrait:noxie_neutral #layout:right
How did you do that??? #speaker:Noxie #portrait:mortis_happy #player portrait:noxie_confused #layout:left
Very very verrry simply, I took that essence and infused it with the preserved limbs of a recently deceased. #speaker:Mortis  #layout:right
And now you should be able to detach those arms and equip these ones and use their power!

In this case, the power would be Ana's X-Ray vision. #speaker:Dearil #portrait:dearil_neutral 

Oooooh, so THAT'S how she knew where the thing was earlier? #speaker:Noxie #player portrait:noxie_thinking #layout:left

Yes. Now when you use her power, you should be able to see it, too. #speaker:Dearil #layout:right
I'll be able to swap out your limbs for you as we keep going.
Maybe we can try it out on that other patch of soul plants up ahead?

~ has_rawEssence = false
~ power_name = "Ana"
~ essence_name = ""
~ mortis_completed = true
->END

=== helloagain ===
Bring back essences and I'll make you more powers! #speaker:Mortis #portrait:mortis_happy #layout:right #player portrait:noxie_neutral
(And I'll continue my research)
->END