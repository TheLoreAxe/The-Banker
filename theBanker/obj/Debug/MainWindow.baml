   M S B A M L   `   `   `  ����D  @theBanker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:theBanker	theBanker  5   	       theBanker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:theBanker     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � ��5
   
   �� 5       �� ImageSource$ squares.png��6    j� Stretch$ UniformToFill=�63   .+�5   
   �� -   5         ��Name$ 
depositBox��5      $
��Left=�6&   $��19��6A   $��551,157,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��148��6�   $��Courier New)�6�   �� 5   
   -   5         ��Name$ depositButton��5      $��Deposit��6(   $
��Left=�6:   $��462,156,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5         ��Name$ listOfAccountsBox��5      $
��Left=�6-   $	��262��6H   $��131,119,0,0q�6U   $	��Top=�6j   $	��227��6�   $��Courier New)�6�   ���	#FFB31A00
���   �$��2,2,2,2q�6  5      �� 5   
   $��
The Banker��6   $��271.8,10,271.8,349q�6%   $��Center=�6A   $��Elephant)�6\   $��40(�6r   $��Center=�6�   $��Center=�6�   $��Center=�6�   $	��280��6�   �� 5   
   -   5        $ withdrawalBox��5      $
��Left=�6)   $��19��6D   $��551,181,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��148��6�   $��Courier New)�6�   �� 5   
   -   5        $ withdrawalButton��5      $��
Withdrawal��6+   $
��Left=�6@   $��462,180,0,0q�6[   $	��Top=�6p   $��75��6�   6�   �� 5   
   -   5         ��Name$ exceptionOutput��5      $�� ��6)   $
��Left=�64   $��462,204,0,0q�6O   $	��Top=�6d   
���  ��$	��100��6�   �� 5   
   -   5        $ interestBox��5      $�� ��6%   $
��Left=�60   $��410,315,0,0q�6K   $	��Top=�6`   $��66��6x   $	��321��6�   $��Center=�6�   $��22(�6�   �� 5   
   -   5        $ calculateInterestBtn��5      $��Calculate Interest��6/   $
��Left=�6L   $��510,271,0,0q�6g   $	��Top=�6|   $	��126��6�   $��19��6�   5      5      