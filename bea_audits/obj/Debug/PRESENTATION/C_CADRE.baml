   M S B A M L   `   `   `  ����E  Abea_audits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:bea_audits.PRESENTATIONbea_audits.PRESENTATION  5   	   %    bea_audits.PRESENTATION.C_CADRE   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:bea_audits.PRESENTATION     5   	   -   5          �Name$  fenetre_ajouter��5   	    � Title$ C_CADRE��5	   	   $��329.362��6   $��460.143��6*    � WindowStartupLocation$ CenterScreen=�6:   ���#001B4C � 	Resources 5
       �� 
TargetType �� Property �� Value��%�  '��       '�� �     '�� �     '�� 2    �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � �� �#002A776+   �� 5       � �� �#005BFF6,   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � �� �#002A776+   �� 5       � ��
 �����6+   �� 5       � �� �#005BFF6,   5      5      .��5      � .+�5   
   �� -   5         ��Name$ titre_ajout��5      $��AJOUTER UNE ENTREPRISE��6%   $��Center=�6F   $��144,21,144.6,0q�6c   $	��Top=�6{   $	��165��6�   $
��Bold"�6�   �� 5   
   $��Nom :��6   $
��Left=�6    $��
110,65,0,0q�6;   $	��Top=�6O   $��45��6g   �� 5    
   -   5         ��Name$	 nom��5       $
��Left=�6   $��26��6:   $��	52,91,0,0q�6F   	 �� TextWrapping$
	 Wrap=�6Y   $	��Top=�6m   $	��165��6�   �� 5"   
   -   5        $ label_adresse��5"      $��	Adresse :��6'   $
��Left=�6;   $��102,120,0,0q�6V   $	��Top=�6k   �� 5#   
   -   5        $ adresse��5#      $
��Left=�6#   $��26��6>   $��
52,146,0,0q�6J   $
	 Wrap=�6^   $	��Top=�6r   $	��165��6�   �� 5%   
   -   5        $��Ajouter��5%      $��Center=�6#   $��
0,0,120,25q�6@   $��Bottom=�6T   $��92��6o   $��30��6z   6�   �� 5&   
   -   5        $��Annuler��5&      $��Center=�6#   $��
120,0,0,25q�6@   $��Bottom=�6T   $��92��6o   $��30��6z   6�   �� 5'   
   -   5        $ label_description��5'      $��Description :��6+   $
��Left=�6C   $��
281,65,0,0q�6^   $	��Top=�6r   �� 5(   
   -	   5        $ description��5(      $
��Left=�6'   $��81��6B   $��
241,91,0,0q�6N   $
	 Wrap=�6b   $	��Top=�6v   $	��159��6�   �� 5)   
   -
   5        
 ��Name$
 slider��5)       �� IsSnapToTickEnabled . $
��Left=�6<   $��
40,151,0,0q�6W   $	��Top=�6k   $	��150��6�    � Maximum$	 100Q�6�    �� TickFrequency$ 1Q�6�   �� 5*   
   -   5        $ 
TXT_slider��5*      $
��Left=�6{   $
	 Wrap=�6�   $	��Top=�6�   $��190,151,0,0q�6�   $��30��6�   ��6&   ��  �� ElementName$ slider�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5+   
   -   5        $ TXB_liaison_ajouter��5+      $
��Left=�6/   $��23��6J   $��
52,203,0,0q�6V   $
	 Wrap=�6j   $	��Top=�6~   $	��161��6�   �� 5,   
   -   5        $ label_liaison��5,      $��Nom de la liaison :��6'   $
��Left=�6E   $��
78,177,0,0q�6`   $	��Top=�6t   �� 5-   
   -   5        $ TBX_label_ajouter��5-      $
��Left=�6-   $��23��6H   $��239,203,0,0q�6T   $
	 Wrap=�6i   $	��Top=�6}   $	��161��6�   �� 5.   
   -   5        $ label_label��5.      $��Nom du label :��6%   $
��Left=�6>   $��278,177,0,0q�6Y   $	��Top=�6n   5/      50      