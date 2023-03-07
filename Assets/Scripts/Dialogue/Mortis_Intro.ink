INCLUDE globals.ink
{Mortis_completed == true: -> helloagain}
//if u have raw essence skip to the essence "cutscene"
{has_rawEssence: -> essence}
Hi! Hello! Salutations! #speaker:Mortis #portrait:mortis_happy #layout:right #player portrait:noxie_thinking
I see that you've already started walking, so why don't we hurry along with the readjustment period? #layout:right
How are those relatively new limbs treating you?
...Where am I? What happened to me? #speaker:Noxie #layout:left
I can't remember anything...
Oh my. #speaker:Mortis #layout:right
Oh my my my
This. 
Is absolutely. 
<color=\#71eb6b>WONDERFUL!!!
Already able to speak?! You're already faring better than my previous attempts! 
Let us skip ahead to the cognitive tests. Can you count to five for me? How many fingers am I holding up?
One, two, three, four, five? #speaker:Noxie #layout:left
~ typing_speed = 0.04
Uh, three fingers...
~ typing_speed = 0.02
Wait
Why am I doing this
Who even are you???
This is a major breakthrough! #speaker:Mortis #layout:right
You're talking back, thinking for yourself, asking QUESTIONS!
I believe I may have finally done it! 
DONE WHAT??? #speaker:Noxie #layout:left
Necromancy, my friend! #speaker:Mortis #layout:right
But not just any necromancy, no no no we are not so simple here. Trans-species necromancy!
I caught your faint little human soul and reengineered it for a demon's body. Of course, this body is made up of multiple different long passed demons, not a single uniform body-
Wait, I DIED??? #speaker:Noxie #layout:left
Like, all the way? 
Well, sure. How else would I have gotten your soul? By extracting it directly? That’s ridiculous. #speaker:Mortis #layout:right
Uh, that doesn’t sound any more crazy than anything else you just told me… #speaker:Noxie #layout:left
Does that mean this is Hell? Are you the Devil? Wait… am I being punished?!
Calm down, I am no such thing. #speaker:Mortis #layout:right
I know nothing of your human life, you were simply one of the thousands of souls that pass through here in the Decay domain and plucked from the chain of the rebirth cycle.
And this is not the Hell you might be imagining, in fact I think the denizens of this place are quite colorful characters!
I think you will find them interesting once you go out and explore for yourself.
In fact this is much less a punishment and more of a… second life, if you will. As long as nothing goes astronomically wrong with your new form!
I wish I could remember what my life was like before I died so I could know how mad I should be right now... #speaker:Noxie #layout:left
Your memory loss is unsurprising. I was unsure how stable they would be traveling from your physical body to your formless soul. #speaker:Mortis #layout:right
You may not even be able to recover them in full, if at all!
Great... #speaker:Noxie #layout:left
Bah, I say do not dwell on the past. You cannot change what you cannot change. #speaker:Mortis #layout:right
All of the action is right here in the present, and our potential in our future!
Moving on!
Now that we have established that the transfer was successful, there is something peculiar about this world that I want to explore with you.
I need you to collect something called essences. They are a piece of a demon's soul that in part forms their identity.
I've observed that demons are able to exchange their essences with each other at their leisure.
These essences are malleable and change as they're passed from person to person, like they are adapting to the new host in a way.
Typically a human soul should not be able to infuse a demon's essence, but you are special!
Not only because your soul has already been fused with a demon's body, but because your body is malleable as well.

Uh, okay...? #speaker:Noxie #layout:left
Will that, like, hurt?

Probably not! #speaker:Mortis #layout:right

//Okay... Why should I be doing this for you anyway? Just cause you resurrected me doesn't mean I owe you anything.

{has_rawEssence: |You'll find out once you find someone who will lend you their essence. Come back to me so I may study the results, please!}
->END

=== essence ===
I see you've found an essence from someone!#speaker:Mortis #portrait:mortis_happy #layout:right #player portrait:noxie_thinking
As I suspected, you can't interact with it as demons normally would.
Allow me.
(Mortis inserts the essence into some kind of machine. It groans and creaks as it processes it.) #portrait:invis #player portrait:invis #layout:none
(Eventually it finishes the task and a glass tube opens up to reveal a pair of arms.)
Voila! I have made you a new pair of arms! #portrait:mortis_happy #player portrait:noxie_thinking #layout:right
How did you do that???#speaker:Noxie #portrait:mortis_happy #player portrait:noxie_thinking #layout:left
As much as I would love to get into the details, I shall simplify it for you.#speaker:Mortis  #layout:right
Very very verrry simply, I took that essence and infused it with the preserved limbs of a recently deceased. 
And now you should be able to detach those arms and equip these ones and use their power!
All thanks to my genius.
~ has_rawEssence = false
~ power_name = "Ciara"
~ essence_name = ""
->END

=== helloagain ===
Bring back essences and I'll make you more powers! #speaker:Mortis #portrait:mortis_happy #layout:right #player portrait:noxie_thinking

->END