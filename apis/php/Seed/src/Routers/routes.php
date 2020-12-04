<?php

declare(strict_types=1);


use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use App\Controllers\UserController;




$app->get('/', UserController::class . ':home');
$app->get('/hello/{name}', function (Request $request, Response $response, array $args) {
    $name = $args['name'];
    
    $response->getBody()->write("Hello, $name");
    return $response;
});
    
    // $app->get('/message', 'MensajesController:home');
    // $app->get('/', 'UserController:home');
