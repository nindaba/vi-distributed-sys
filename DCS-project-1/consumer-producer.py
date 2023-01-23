'''

Group members:
--------------
Nindaba Arthur 57086
Rashi Sonavani 56480
Manthan Pathak 56458
'''

from threading import Thread, Semaphore
import time
import random

buffer = []
nonEmpty = Semaphore(2);

class ProducerThread(Thread):
    def run(self):
        nums = range(5)
        global buffer
        while True:
            nonEmpty.acquire()
            num = random.choice(nums)
            buffer.append(num)
            print ("Produced", num)
            nonEmpty.release()
            time.sleep(random.randint(2,5))


class ConsumerThread(Thread):
    def run(self):
        global buffer
        while True:
            nonEmpty.acquire()
            if len(buffer) > 0:
                num = buffer.pop(0)
                print("Consumed", num)
            nonEmpty.release()
            time.sleep(random.randint(0,5))


ProducerThread().start()
ConsumerThread().start()
