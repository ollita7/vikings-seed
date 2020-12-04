<?php
namespace App\Controllers;

use Psr\Container\ContainerInterface;

class UserController
{
    protected $container;
    private $loggin = null;
    private $objFirebaseHelper = null;


    public function __construct(ContainerInterface $container)
    {
        $this->container = $container;
        $this->loggin = $this->container->get('logger');
        $this->objFirebaseHelper = $this->container->get('FirebaseHelper');
    }

    public function home( $request, $response) {
        $this->loggin->error('Something interesting happened');
        ($this->objFirebaseHelper)->enviar_notificacion();
        return 'User-Controller';
    }
}