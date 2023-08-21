import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { CampaignsComponent } from './campaigns/campaigns.component';
import { RolesComponent } from 'app/roles/roles.component';
import { CampaignTypesComponent } from 'app/campaignTypes/campaignTypes.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
///app-routing.module.ts.place1///
@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent, canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'campaigns', component: CampaignsComponent, data: { permission: 'Pages.Campaigns' }, canActivate: [AppRouteGuard] },
                    { path: 'campaignTypes', component: CampaignTypesComponent, data: { permission: 'Pages.CampaignTypes' }, canActivate: [AppRouteGuard] },
                    { path: 'update-password', component: ChangePasswordComponent },
                    ///app-routing.module.ts.place2///
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
