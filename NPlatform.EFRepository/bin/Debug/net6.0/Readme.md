### ��Ʒ���ƣ� Not Platform
### 
### ���ߣ�Dongliang Yi
### ����˵����
 Not Platform �ײ���ּ�
 Լ����淶�ˣ�
 applications
 DI
 Domains
 Repositories
 Result
 Dto

 ### CQRS ˵����
 ����MediatR ʵ�֡�
 �̳����� IDTO->ICommand(IEvent)-> CommandBase(EventBase) ->CommandObject(EventObject) .
 ҵ��ʵ���е��޸�������װCommandObject(Controller��)--> Bus.SendCommand(Controller��) --> CommandHander(DommainService OR application )-->���òִ�ʵ�����л�
 ҵ��ʵ���еĲ�ѯ������װ Query ����  (Controller��)--> ���ò�ѯ����(DommainService OR application )-->���òִ���

### ���¼�¼��
2021/9/8 NPlatform �ײ���ּ� start��