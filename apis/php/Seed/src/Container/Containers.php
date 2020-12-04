<?php

$container = $app->getContainer();


$container['logger'] = function($c) {
    $logger = new \Monolog\Logger('my_logger');
    $file_handler = new \Monolog\Handler\StreamHandler('../logs/app.log');
    $logger->pushHandler($file_handler);
    return $logger;
};

$container['FirebaseHelper'] = function ($c) {
    $objFirebaseHelper = new \App\Helpers\FirebaseHelper();
    return $objFirebaseHelper;
};




