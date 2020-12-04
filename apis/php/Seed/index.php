<?php
require_once  __DIR__ .'/vendor/autoload.php';
define('DS', DIRECTORY_SEPARATOR);
define('ROOT', realpath(dirname(__FILE__)).DS);

$app = new \Slim\App();
$container = $app->getContainer();

// Register Routers.
require_once __DIR__ . '/src/Routers/Routes.php';
require_once __DIR__ . '/src/Container/Containers.php';

$app->run();