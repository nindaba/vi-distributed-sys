'''

Group members:
--------------
Nindaba Arthur 57086
Rashi Sonavani 56480
Manthan Pathak 56458
'''

from threading import Thread, Condition
import time
import random

buffer = []
nonEmpty = Condition()

class ProducerThread(Thread):
    def run(self):
        nums = range(5)
        global buffer
        while True:
            nonEmpty.acquire()
            num = random.choice(nums)
            buffer.append(num)
            print ("Produced", num)
            nonEmpty.notify()
            nonEmpty.release()
            time.sleep(random.randint(2,5))


class ConsumerThread(Thread):
    def run(self):
        global buffer
        while True:
            nonEmpty.acquire()
            if not buffer:
                print ("Nothing in buffer, consumer is waiting")
                nonEmpty.wait()
                print ("Producer added something to buffer and notified the consumer")
            num = buffer.pop(0)
            print("Consumed", num)
            nonEmpty.notify()
            nonEmpty.release()
            time.sleep(random.randint(0,5))


ProducerThread().start()
ConsumerThread().start()