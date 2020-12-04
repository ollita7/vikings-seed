<?php
namespace App\Helpers;

use Kreait\Firebase\Factory;
use Kreait\Firebase\Messaging\CloudMessage;


class FirebaseHelper 
{
    //TODO:: this will receive userid, device token and a message object
    public function enviar_notificacion(){

        $factory = (new Factory)->withServiceAccount(ROOT.'src'.DS.'Configs'.DS.'firebase_credentials.json');
        $deviceToken = 'fwZw3gqi7iI:APA91bHH_etu2eize3dkb3ac0pmeBieOzhOER29ctwPeMzMfqnxhYmpPgVDAUsktQdFW1MUuUqtx7WkHepFtReDTRlRqMH5_i3lgxVxDfAgSmwGfM8BforYCj1nlvGXB8xS38YIg0OK7';

        $messaging = $factory->createMessaging();

        $message = CloudMessage::withTarget('token', $deviceToken);
        $message = CloudMessage::fromArray(['token' => $deviceToken]);
        
        $messaging->send($message);
        

        // $messaging = $factory->createMessaging();
        // $message = CloudMessage::withTarget(/* see sections below */)
        //     ->withNotification(Notification::create('Title', 'Body'))
        //     ->withData(['key' => 'value']);

    }

}
