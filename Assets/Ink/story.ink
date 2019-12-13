VAR unpack = false
VAR chocolate = false
VAR late = false
EXTERNAL Break()


 


=== START

#watchers:WATCHERS_FIRST_LOOP
Welcome valued ghuest, we hope you enjoy your stay with us.

-

*[Take your bags up to your room.] 
Your bags are heavy. Your room is small.
{CustomEvent("BACKGROUND0")}
-
*[Unpack.]
~unpack = true

You get your clothes out of your suitcase and put them in the wardrobe. The wardrobe is much bigger than it needs to be and your small selection of clothes looks out of place.

You put your toothbrush in the little cup on the sink in the bathroom.

You feel a little more at home, and have a look around.

In your room there is a bed, a chair, a desk, a wardrobe, a TV, a window, and a small ensuite bathroom.
->BLEEPBLOOP

*[Don't bother.]

You'll be leaving soon anyway so don't see the point in unpacking. You leave your clothes in your suitcase and lean it against the wall.

You look around.

In your room there is a bed, a chair, a desk, a wardrobe, a TV, a window, and a small ensuite bathroom.
->BLEEPBLOOP


->DONE

=BLEEPBLOOP

{->MAIN_OPTIONS|->MAIN_OPTIONS|->HUNGRY}

->DONE

=MAIN_OPTIONS
{CustomEvent("BACKGROUND0")}
    *[Sit on the bed.]You sit on the bed.
    #watchers:WATCHERS_BED
    You can feel the springs. The sheets are discoloured but cling tight to the old mattress.
    
    After a while you get up.
    
    *[Sit at the desk.]You sit at the desk.
    
    The chair is uncomfortable, it feels like many people have sat here before.
    
    On the desk is a stack of information, a phone, a kettle and mugs, a lamp.
    
    ->DESK
        
    
    *[Go to the window.] 
    {CustomEvent("BACKGROUND1")}
    You go to the window.
    
    #watchers:WATCHERS_WINDOW
    The window is foggy, your room overlooks the car park. It is starting to get dark.
    
    Cars lie dormant in neat lines, engines idle, headlights point in your direction.
    
        **[Shut the curtains.]
         {CustomEvent("BACKGROUND0")}
        
        You shut the curtains to give yourself some more privacy.
        
        It feels as though you are being watched.
        
        **[Open the window.]
        
        You open the window to get some fresh air. You can smell cigarette smoke and exhaust fumes from the car park.
        
        In the distance you can hear the hum of crickets.
        
    
    *[Go to the bathroom.] 
    {CustomEvent("BACKGROUND2")}
    You go to the bathroom.
    #watchers:WATCHERS_BATHROOM
    The light is unnatural and you are forced to squint.
    
    Although the toilet paper is clearly not new there is a small sticker sealing it. You use the toilet.
    
    You wash your hands with the celophane-sealed bar soap.
    
-

->BLEEPBLOOP
 
=HUNGRY
 
#watchers:WATCHERS_BORED
You are hungry and it is getting late.

*[Go down to the restaurant.] 
{CustomEvent("BACKGROUND3")}
You go down to the restaurant. It'd be nice to get out of the room for a while.
~chocolate = true

The food is expensive and you have a few drinks.
When you return to your room you notice there is a chocolate on your pillow, and your suitcase has moved across the room.

->AFTER_DINNER
{CustomEvent("BACKGROUND0")}
*[Order room service.]You order some room service.

It's very expensive but you don't want to leave your room.

You feel bloated and full and a little drunk.

->AFTER_DINNER

=AFTER_DINNER
*[Get something from the mini bar.]

You'd quite like to have a bit more to drink. It's all expensive, but you've paid enough money now to justify it.

You drink.

{
-chocolate == true:
<>.. and you eat the pillow chocolate. It tastes like chalk.
-else:
->AFTER_DINNER
}

->AFTER_DINNER
    

*[Watch TV.]

You sit on your bed and turn the TV on. You flick through some channels, but can't seem to decide on anything.

After a while you become bored.

->AFTER_DINNER

*[Brush your teeth.]
{CustomEvent("BACKGROUND2")}
You go to the bathroom to brush your teeth. There is a mark on the wall behind the sink, presumably made by someone who stayed here before.

Your mouth feels fresh now.

->AFTER_DINNER


*[Go to sleep.]

You get into bed.

The sheets are so tight against the bed that it is hard to get underneath them, and when you do, you feel awkward, as if you shouldn't be doing this.

    **[You had asked for a wake up call.]
    
    You sleep well and are woken up at 8 by a phonecall from the reception.
    
    **[You had not asked for a wake up call.]
    ~late=true
    You sleep well... too well. It is now 11 and you are supposed to check out soon.
    
    --
    
    You eyes are gunky and you need to brush your teeth.
    
        ***[You go to the bathroom.]
         {CustomEvent("BACKGROUND2")}
            You brush your teeth, use the toilet, have a shower. 
            
            The free soap and shampoo isn't what you are used to. You feel clean, but uncomfortable.
            
                ****[Get dressed.]
                {CustomEvent("BACKGROUND0")}
                {
                - unpack == true:
                You get your clothes out of the wardrobe and get dressed.
                - else:
                You get your clothes out of your suitcase and get dressed.
                }
                
                {
                - late == true:
                You are too late for breakfast so head down to the reception to check out.
                ->CHECK_OUT
                -else:
                You are hungry.
                }
                
                    *****[You had already paid for breakfast.]
                    ->BREAKFAST
                    *****[You didn't want to spend more.]
                    You decide you might as well just go and check out.
                    ->CHECK_OUT
        
        
->DONE

=BREAKFAST
{CustomEvent("BACKGROUND3")}
The restaurant is heaving with other ghuests, sweating and dashing between buffet stations.

You eat more than you are capable of, and drink too much caffeine.

Time to check out now.
->CHECK_OUT

->DONE

=CHECK_OUT
{CustomEvent("BACKGROUND0")}
The reception is quiet. Your bag squeaks as you wheel it behind you.

You trip on the rug in the middle of the room, and look down at your feet.

You notice the muddy print of a bare foot in the centre of the otherwise pristine floral pattern.

You wonder how long it has been there, and why they haven't cleaned it up.

*[Next ghuest.]
    {CustomEvent("RESET_STORY")}
    ->END

->DONE


=DESK

        *[Read the information.]You read the information.
        
        It doesn't tell you much you didn't already know.
            
        *[Use the phone.]
            
        You already crave the voice of someone else.
            
            **[Ring the reception.]You ring the reception.
                
            "What can we help you with?" they say.
            
            "How do I access the free wifi?" you say.
            
            "There is a card with a code next to your bed," they say.
            
            "Thank you very much," you say.
            
            
                
            **[Ring an old friend.]You ring an old friend.
            
            "You'll never believe where I am," you say.
            
            "I haven't heard your voice in such a long time," they say.
            
            "This is so weird," you say.
            
            "You shouldn't have called," they say.
            
        
                
            **[Ring your partner.]You ring your partner.
            
            "I'm glad you've made it safely," they say.
            
            "Probably going to watch some TV soon," you say.
            
            "I'm very jealous," they say.
            
            "I miss you already," you say.
            
            
            
        *[Make some tea.]
        
        You boil the kettle, you put a teabag in a mug, you pour the water, you add some milk.
        
        It tastes dusty. You want something else instead now.
        
        
            
        *[Turn on the lamp.]You turn on the lamp.
        {CustomEvent("BACKGROUND4")}
        It is a little brighter now.
    
        
        *[Get up.]
        
        You get up.
        ->BLEEPBLOOP
        
    -
    
    {->DESK|You don't want to sit at the desk anymore, the chair is hurting your back.->BLEEPBLOOP}

->DONE

 == function Break() ==
 ~return