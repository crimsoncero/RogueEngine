using RogueEngine;
using RogueEngine.Renderer;
using RogueEngine.Util;

var log = new FiniteQueue<int>(5);

log.Enqueue(0);
log.Enqueue(1);
log.Enqueue(2);
log.Enqueue(3);
log.Dequeue();
log.Enqueue(4);
log.Enqueue(5);
log.Enqueue(6);
log.Enqueue(7);
log.Enqueue(8);
log.Enqueue(9);
log.Enqueue(10);


