INCLUDE globals.ink

//if u have raw essence skip to the essence "cutscene"
{has_rawEssence: -> essence}
Hi! Hello! Salutations! #speaker:Mortis #portrait:mortis_happy #layout:right #player portrait:noxie_thinking
I see that you've already started walking, so why don't we hurry along with the readjustment period? #layout:right
How are those relatively new limbs treating you?
Can you tell me what happened to me first? #speaker:Noxie #layout:left
I can't remember anything...
Oh my. #speaker:Mortis #layout:right
Oh my my my
This. Is absolutely. WONDERFUL!
Can you count to five for me? Tell me what's on your mind, are you certain you remember nothing? At least you remember how to speak it seems... How many fingers am I holding up?
One, two, three, four, five? Uh... remember... remember... #speaker:Noxie #layout:left
Wait
Why am I doing this
Who are you?!
This is a major breakthrough! #speaker:Mortis #layout:right
You're talking back, thinking for yourself, asking questions!
I believe I may have finally done it! 
DONE WHAT??? #speaker:Noxie #layout:left
Necromancy, my friend! #speaker:Mortis #layout:right
But not just any necromancy, no no no we are not so simple here.
I caught your faint little human soul and reengineered it for a demon's body.
Truly fascinating stuff!
You don't know how many times I've gone through this experiment-
Wait, I DIED??? #speaker:Noxie #layout:left
Like, all the way? 
Also... I'm a demon now? Does that mean this is Hell? Are you the Grim Reaper?
Calm down, calm down, I am no such thing. #speaker:Mortis #layout:right
And this is not the Hell you might be imagining, in fact I think the denizens of this place are quite the colorful characters!
Not to mention, you're one of them now, so do not worry about standing out from the crowd.
I wish I could remember what my life was like before I died so I know how mad I should be right now. #speaker:Noxie #layout:left
Or... maybe grateful? Hm...
Your memory loss is unsurprising. I was unsure how stable they would be travelling from your physical body to your formless soul. #speaker:Mortis #layout:right
You may not even be able to recover them in full, if at all!
Great... #speaker:Noxie #layout:left
Bah, I say do not dwell on the past. You cannot change what you cannot change. #speaker:Mortis #layout:right
All of the action is right here in the present, and our potential in our future!
Wow, did you come up with that catchphrase too? #speaker:Noxie #layout:left
I spend many hours on my patents. #speaker:Mortis #layout:right
Moving on!
Now that we have established that the transfer was successful, there is something peculiar about this world that I want to explore with you.
//cont from here

I need you to collect something called essences. They are a part of a demon's soul that in part forms their identity.
I've observed that demons are able to exchange their essences with each other at their leisure.
These essences are malleable and change as they're passed from person to person, like they are adapting to the new host in a way.
//By infusing them into your soul, you physically adopt new characteristics such as powers and growths upon your body.
Typically a human soul should not be able to infuse a demon's essence, but you are special!
Not only because your soul has already been fused with a demon's body, but because your body is malleable as well.
Uh, okay...? #speaker:Noxie #layout:left
Will that, like, hurt?
Probably not! #speaker:Mortis #layout:right
{has_rawEssence: |You'll find out once you find someone who will lend you their essence. Come back to me so I may study the results, please!}
->END

=== essence ===
I see you've found an essence from someone!#speaker:Mortis #portrait:mortis_happy #layout:right
As I suspected, you can't interact with it as demons normally would.
Allow me.
(Mortis inserts the essence into some kind of machine. It groans and creaks as it processes it.) #portrait:invisiblePortrait #layout:none
(Eventually it finishes the task and a glass tube opens up to reveal a pair of arms.)
Voila! I have made you a new pair of arms! #portrait:mortis_happy #layout:right
How did you do that???#speaker:Noxie #portrait:default #layout:left
As much as I would love to get into the details, I shall simplify it for you.#speaker:Mortis #portrait:mortis_happy  #layout:right
Very very verrry simply, I took that essence and infused it with the preserved limbs of a recently deceased. 
And now you should be able to detach those arms and equip these ones and use their power!
All thanks to my genuis.
~ has_rawEssence = false
~ power_name = "Ciara"
~ essence_name = ""
->END